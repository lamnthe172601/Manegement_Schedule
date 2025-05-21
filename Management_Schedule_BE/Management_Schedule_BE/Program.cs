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

var builder = WebApplication.CreateBuilder(args);

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

#region Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IStudySessionService, StudySessionService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<JWTConfig>();
#endregion

#region Controllers
builder.Services.AddControllers();
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStoreAPI", Version = "v1" });
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
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
