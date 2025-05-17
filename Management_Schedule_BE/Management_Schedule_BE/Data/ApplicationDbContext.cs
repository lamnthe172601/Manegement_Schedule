using Microsoft.EntityFrameworkCore;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SessionCode> SessionCodes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<StudentTuitionHistory> StudentTuitionHistories { get; set; }
        public DbSet<TeacherSalaryHistory> TeacherSalaryHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configure Teacher
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.TeacherID);

            // Configure Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.StudentID);

            // Configure Course
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseName)
                .IsUnique();

            // Configure Class
            modelBuilder.Entity<Class>()
                .HasIndex(c => c.ClassName)
                .IsUnique();

            // Configure Tuition
            modelBuilder.Entity<Tuition>()
                .HasIndex(t => t.TuitionName)
                .IsUnique();

            // Configure Salary
            modelBuilder.Entity<Salary>()
                .HasIndex(s => s.SalaryName)
                .IsUnique();
        }
    }
} 