using Microsoft.EntityFrameworkCore;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Management_Schedule_BE.Helpers.Validators;
using Management_Schedule_BE.Helpers.Mappings;

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
#endregion

#region Controllers
builder.Services.AddControllers();
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
