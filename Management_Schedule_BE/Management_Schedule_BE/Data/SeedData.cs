using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Management_Schedule_BE.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Users
            var users = new List<User>
            {
                new User { UserID = 1, Email = "admin@example.com", PasswordHash = "hashed_password", Role = 1, FullName = "Admin User", Gender = "M", DateOfBirth = new DateTime(1990, 1, 1), Phone = "0123456789", Status = 1 },
                new User { UserID = 2, Email = "teacher1@example.com", PasswordHash = "hashed_password", Role = 2, FullName = "Nguyễn Văn A", Gender = "M", DateOfBirth = new DateTime(1985, 5, 15), Phone = "0123456781", Status = 1 },
                new User { UserID = 3, Email = "teacher2@example.com", PasswordHash = "hashed_password", Role = 2, FullName = "Trần Thị B", Gender = "F", DateOfBirth = new DateTime(1988, 8, 20), Phone = "0123456782", Status = 1 },
                new User { UserID = 4, Email = "student1@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Lê Văn C", Gender = "M", DateOfBirth = new DateTime(2000, 3, 10), Phone = "0123456783", Status = 1 },
                new User { UserID = 5, Email = "student2@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Phạm Thị D", Gender = "F", DateOfBirth = new DateTime(2001, 6, 25), Phone = "0123456784", Status = 1 },
                new User { UserID = 6, Email = "student3@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Hoàng Văn E", Gender = "M", DateOfBirth = new DateTime(2002, 9, 5), Phone = "0123456785", Status = 1 },
                new User { UserID = 7, Email = "student4@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Đỗ Thị F", Gender = "F", DateOfBirth = new DateTime(2000, 12, 15), Phone = "0123456786", Status = 1 },
                new User { UserID = 8, Email = "student5@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Vũ Văn G", Gender = "M", DateOfBirth = new DateTime(2001, 4, 20), Phone = "0123456787", Status = 1 },
                new User { UserID = 9, Email = "student6@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Ngô Thị H", Gender = "F", DateOfBirth = new DateTime(2002, 7, 30), Phone = "0123456788", Status = 1 },
                new User { UserID = 10, Email = "student7@example.com", PasswordHash = "hashed_password", Role = 3, FullName = "Đặng Văn I", Gender = "M", DateOfBirth = new DateTime(2000, 11, 8), Phone = "0123456790", Status = 1 }
            };
            modelBuilder.Entity<User>().HasData(users);

            // Seed Teachers
            var teachers = new List<Teacher>
            {
                new Teacher { TeacherID = 2, ProfileImageUrl = "teacher1.jpg", FacebookUrl = "facebook.com/teacher1", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Teacher { TeacherID = 3, ProfileImageUrl = "teacher2.jpg", FacebookUrl = "facebook.com/teacher2", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);

            // Seed Students
            var students = new List<Student>
            {
                new Student { StudentID = 4, Level = 1, EnrollmentDate = DateTime.Now.AddMonths(-6), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 5, Level = 2, EnrollmentDate = DateTime.Now.AddMonths(-5), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 6, Level = 1, EnrollmentDate = DateTime.Now.AddMonths(-4), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 7, Level = 3, EnrollmentDate = DateTime.Now.AddMonths(-3), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 8, Level = 2, EnrollmentDate = DateTime.Now.AddMonths(-2), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 9, Level = 1, EnrollmentDate = DateTime.Now.AddMonths(-1), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Student { StudentID = 10, Level = 2, EnrollmentDate = DateTime.Now, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Student>().HasData(students);

            // Seed Courses
            var courses = new List<Course>
            {
                new Course { CourseID = 1, CourseName = "Tiếng Anh Cơ Bản", Description = "Khóa học tiếng Anh cho người mới bắt đầu", Price = 2000000, IsSelling = true, IsComingSoon = false, IsPro = false, IsCompletable = true, DiscountPercent = 0, Duration = 48, Level = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Course { CourseID = 2, CourseName = "Tiếng Anh Giao Tiếp", Description = "Khóa học tiếng Anh giao tiếp cơ bản", Price = 2500000, IsSelling = true, IsComingSoon = false, IsPro = false, IsCompletable = true, DiscountPercent = 10, Duration = 60, Level = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Course { CourseID = 3, CourseName = "Tiếng Anh Thương Mại", Description = "Khóa học tiếng Anh thương mại", Price = 3000000, IsSelling = true, IsComingSoon = false, IsPro = true, IsCompletable = true, DiscountPercent = 0, Duration = 72, Level = 3, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Course { CourseID = 4, CourseName = "IELTS Preparation", Description = "Khóa học luyện thi IELTS", Price = 5000000, IsSelling = true, IsComingSoon = false, IsPro = true, IsCompletable = true, DiscountPercent = 5, Duration = 96, Level = 4, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Course { CourseID = 5, CourseName = "TOEIC Master", Description = "Khóa học luyện thi TOEIC", Price = 4000000, IsSelling = true, IsComingSoon = false, IsPro = true, IsCompletable = true, DiscountPercent = 0, Duration = 84, Level = 3, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Course>().HasData(courses);

            // Seed Classes
            var classes = new List<Class>
            {
                new Class { ClassID = 1, ClassName = "Basic English A1", CourseID = 1, MaxStudents = 20, StartDate = DateTime.Now.AddMonths(-3), EndDate = DateTime.Now.AddMonths(3), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Class { ClassID = 2, ClassName = "Basic English A2", CourseID = 1, MaxStudents = 20, StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now.AddMonths(4), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Class { ClassID = 3, ClassName = "Conversation English B1", CourseID = 2, MaxStudents = 15, StartDate = DateTime.Now.AddMonths(-1), EndDate = DateTime.Now.AddMonths(5), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Class { ClassID = 4, ClassName = "Business English B2", CourseID = 3, MaxStudents = 15, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Class { ClassID = 5, ClassName = "IELTS Preparation C1", CourseID = 4, MaxStudents = 10, StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(7), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Class>().HasData(classes);

            // Seed StudySessions
            var studySessions = new List<StudySession>
            {
                new StudySession { StudySessionId = 1, DisplayName = "Ca 1", StartTime = "07:30", EndTime = "09:00", Description = "Ca học sáng", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudySession { StudySessionId = 2, DisplayName = "Ca 2", StartTime = "09:15", EndTime = "10:45", Description = "Ca học sáng", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudySession { StudySessionId = 3, DisplayName = "Ca 3", StartTime = "13:30", EndTime = "15:00", Description = "Ca học chiều", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudySession { StudySessionId = 4, DisplayName = "Ca 4", StartTime = "15:15", EndTime = "16:45", Description = "Ca học chiều", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudySession { StudySessionId = 5, DisplayName = "Ca 5", StartTime = "18:00", EndTime = "19:30", Description = "Ca học tối", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<StudySession>().HasData(studySessions);

            // Seed Schedules
            var schedules = new List<Schedule>
            {
                new Schedule { ScheduleID = 1, ClassID = 1, TeacherID = 2, StudySessionId = 1, SessionCode = "MON-1", DayOfWeek = 2, TimeSlot = "07:30-09:00", Room = "Room 101", Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Schedule { ScheduleID = 2, ClassID = 1, TeacherID = 2, StudySessionId = 3, SessionCode = "WED-3", DayOfWeek = 4, TimeSlot = "13:30-15:00", Room = "Room 101", Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Schedule { ScheduleID = 3, ClassID = 2, TeacherID = 3, StudySessionId = 2, SessionCode = "TUE-2", DayOfWeek = 3, TimeSlot = "09:15-10:45", Room = "Room 102", Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Schedule { ScheduleID = 4, ClassID = 2, TeacherID = 3, StudySessionId = 4, SessionCode = "THU-4", DayOfWeek = 5, TimeSlot = "15:15-16:45", Room = "Room 102", Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Schedule { ScheduleID = 5, ClassID = 3, TeacherID = 2, StudySessionId = 5, SessionCode = "FRI-5", DayOfWeek = 6, TimeSlot = "18:00-19:30", Room = "Room 103", Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Schedule>().HasData(schedules);

            // Seed Lessons
            var lessons = new List<Lesson>
            {
                new Lesson { LessonID = 1, LessonName = "Bài 1: Giới thiệu", Description = "Giới thiệu về khóa học", ContentUrl = "lesson1.mp4", CourseID = 1, Position = 1, IsPublished = true, Duration = 45, Type = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Lesson { LessonID = 2, LessonName = "Bài 2: Chào hỏi", Description = "Cách chào hỏi trong tiếng Anh", ContentUrl = "lesson2.mp4", CourseID = 1, Position = 2, IsPublished = true, Duration = 45, Type = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Lesson { LessonID = 3, LessonName = "Bài 3: Số đếm", Description = "Học về số đếm trong tiếng Anh", ContentUrl = "lesson3.mp4", CourseID = 1, Position = 3, IsPublished = true, Duration = 45, Type = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Lesson { LessonID = 4, LessonName = "Bài 4: Thực hành", Description = "Bài tập thực hành", ContentUrl = "lesson4.mp4", CourseID = 1, Position = 4, IsPublished = true, Duration = 45, Type = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Lesson { LessonID = 5, LessonName = "Bài 5: Kiểm tra", Description = "Bài kiểm tra kiến thức", ContentUrl = "lesson5.mp4", CourseID = 1, Position = 5, IsPublished = true, Duration = 45, Type = 3, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Lesson>().HasData(lessons);

            // Seed StudentClassEnrollments
            var enrollments = new List<StudentClassEnrollment>
            {
                new StudentClassEnrollment { EnrollmentID = 1, StudentID = 4, ClassID = 1, EnrollmentDate = DateTime.Now.AddMonths(-3), TotalTuitionDue = 2000000, TuitionPaid = 1000000, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentClassEnrollment { EnrollmentID = 2, StudentID = 5, ClassID = 1, EnrollmentDate = DateTime.Now.AddMonths(-3), TotalTuitionDue = 2000000, TuitionPaid = 2000000, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentClassEnrollment { EnrollmentID = 3, StudentID = 6, ClassID = 2, EnrollmentDate = DateTime.Now.AddMonths(-2), TotalTuitionDue = 2000000, TuitionPaid = 1000000, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentClassEnrollment { EnrollmentID = 4, StudentID = 7, ClassID = 2, EnrollmentDate = DateTime.Now.AddMonths(-2), TotalTuitionDue = 2000000, TuitionPaid = 2000000, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentClassEnrollment { EnrollmentID = 5, StudentID = 8, ClassID = 3, EnrollmentDate = DateTime.Now.AddMonths(-1), TotalTuitionDue = 2500000, TuitionPaid = 1250000, Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<StudentClassEnrollment>().HasData(enrollments);

            // Seed Tuitions
            var tuitions = new List<Tuition>
            {
                new Tuition { TuitionID = 1, TuitionName = "Học phí tháng 1", Fee = 1000000, Type = 1, DueDate = DateTime.Now.AddMonths(1), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Tuition { TuitionID = 2, TuitionName = "Học phí tháng 2", Fee = 1000000, Type = 1, DueDate = DateTime.Now.AddMonths(2), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Tuition { TuitionID = 3, TuitionName = "Học phí tháng 3", Fee = 1000000, Type = 1, DueDate = DateTime.Now.AddMonths(3), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Tuition { TuitionID = 4, TuitionName = "Học phí tháng 4", Fee = 1000000, Type = 1, DueDate = DateTime.Now.AddMonths(4), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Tuition { TuitionID = 5, TuitionName = "Học phí tháng 5", Fee = 1000000, Type = 1, DueDate = DateTime.Now.AddMonths(5), Status = 1, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<Tuition>().HasData(tuitions);

            // Seed StudentTuitionHistory
            var tuitionHistory = new List<StudentTuitionHistory>
            {
                new StudentTuitionHistory { PaymentID = 1, EnrollmentID = 1, TuitionID = 1, AmountPaid = 1000000, PaymentDate = DateTime.Now.AddMonths(-2), PaymentMethod = 1, Status = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentTuitionHistory { PaymentID = 2, EnrollmentID = 2, TuitionID = 1, AmountPaid = 1000000, PaymentDate = DateTime.Now.AddMonths(-2), PaymentMethod = 2, Status = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentTuitionHistory { PaymentID = 3, EnrollmentID = 2, TuitionID = 2, AmountPaid = 1000000, PaymentDate = DateTime.Now.AddMonths(-1), PaymentMethod = 2, Status = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentTuitionHistory { PaymentID = 4, EnrollmentID = 3, TuitionID = 1, AmountPaid = 1000000, PaymentDate = DateTime.Now.AddMonths(-1), PaymentMethod = 1, Status = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new StudentTuitionHistory { PaymentID = 5, EnrollmentID = 4, TuitionID = 1, AmountPaid = 1000000, PaymentDate = DateTime.Now.AddMonths(-1), PaymentMethod = 3, Status = 2, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            };
            modelBuilder.Entity<StudentTuitionHistory>().HasData(tuitionHistory);
        }
    }
} 