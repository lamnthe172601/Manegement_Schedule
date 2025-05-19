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
        public DbSet<StudySession> StudySessions { get; set; }
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

            // Configure CreatedAt and ModifiedAt for all entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.FindProperty("CreatedAt") != null)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property("CreatedAt")
                        .HasDefaultValueSql("GETDATE()");
                }

                if (entityType.FindProperty("ModifiedAt") != null)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property("ModifiedAt")
                        .HasDefaultValueSql("GETDATE()");
                }
            }
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User || e.Entity is Teacher || e.Entity is Student || 
                           e.Entity is Course || e.Entity is Class || e.Entity is Lesson || 
                           e.Entity is StudySession || e.Entity is Schedule || e.Entity is Tuition || 
                           e.Entity is Salary || e.Entity is StudentTuitionHistory || 
                           e.Entity is TeacherSalaryHistory)
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                var entity = entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.GetType().GetProperty("CreatedAt")?.SetValue(entity, DateTime.Now);
                }

                entity.GetType().GetProperty("ModifiedAt")?.SetValue(entity, DateTime.Now);
            }

            return base.SaveChanges();
        }
    }
} 