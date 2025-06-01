using Microsoft.EntityFrameworkCore;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Management_Schedule_BE.Helpers.Validators;
using Management_Schedule_BE.Helpers.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Management_Schedule_BE.Services.SystemSerivce;
using System.Security.Claims;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Management_Schedule_BE.DTOs;
using Amazon.Runtime;
using Amazon.S3;
using Management_Schedule_BE.Services.SystemSerivce.StoreService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<R2Config>(builder.Configuration.GetSection("R2"));
var r2Config = builder.Configuration.GetSection("R2").Get<R2Config>();

#region s3Client with DI
var s3Config = new AmazonS3Config { ServiceURL = r2Config.Endpoint };
var credentials = new BasicAWSCredentials(r2Config.AccessKey, r2Config.SecretKey);
builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(credentials, s3Config));
#endregion

#region DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Cors
builder.Services.AddCors(options => 
   options.AddDefaultPolicy(policy => 
   policy
         .AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod()
   )
);
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(CourseMappingProfile));
builder.Services.AddAutoMapper(typeof(LessonMappingProfile));
builder.Services.AddAutoMapper(typeof(ClassMappingProfile));
builder.Services.AddAutoMapper(typeof(StudySessionMappingProfile));
builder.Services.AddAutoMapper(typeof(ScheduleMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
#endregion

#region FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateLessonDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClassDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateScheduleDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateStudySessionDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCourseDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateLessonDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateClassDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateScheduleDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateStudySessionDTOValidator>();
builder.Services.AddFluentValidationAutoValidation();
#endregion

#region OData
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(100)
        .Count()
        .Expand()
        .AddRouteComponents("api", GetEdmModel())
    );

// Custom response cho lỗi validation
builder.Services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            );

        var responseObj = new
        {
            status = "error",
            message = "Validation failed",
            errors = errors
        };

        return new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(responseObj);
    };
});
#endregion

#region Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IStudySessionService, StudySessionService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<JWTConfig>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IStorageService, R2StorageService>();
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Management_Schedule", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
#endregion

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))  
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                status = "error",
                message = "Bạn chưa đăng nhập hoặc token hết hạn",
                data = (object)null,
                errors = (object)null
            });
            return context.Response.WriteAsync(result);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                status = "error",
                message = "Bạn không có quyền truy cập",
                data = (object)null,
                errors = (object)null
            });
            return context.Response.WriteAsync(result);
        }
    };
});
#endregion
var app = builder.Build();

#region Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

// Đăng ký middleware wrap response
app.UseMiddleware<Management_Schedule_BE.Middlewares.ResponseWrapperMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
#endregion

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    
    // Đăng ký các entity set
    builder.EntitySet<Schedule>("Schedules");
    builder.EntitySet<Course>("Courses");
    builder.EntitySet<Lesson>("Lessons");
    builder.EntitySet<Class>("Classes");
    builder.EntitySet<StudySession>("StudySessions");
    builder.EntitySet<StudentClassEnrollment>("StudentClassEnrollments");
    builder.EntitySet<StudentTuitionHistory>("StudentTuitionHistories");
    return builder.GetEdmModel();
}
