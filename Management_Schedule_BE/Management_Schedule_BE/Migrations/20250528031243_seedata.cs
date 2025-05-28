using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class seedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "CreatedAt", "Description", "DiscountPercent", "Duration", "IsComingSoon", "IsCompletable", "IsPro", "IsSelling", "Level", "ModifiedAt", "Price", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh Cơ Bản", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3598), "Khóa học tiếng Anh cho người mới bắt đầu", (byte)0, 48, false, true, false, true, (byte)1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3598), 2000000m, null },
                    { 2, "Tiếng Anh Giao Tiếp", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3603), "Khóa học tiếng Anh giao tiếp cơ bản", (byte)10, 60, false, true, false, true, (byte)2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3603), 2500000m, null },
                    { 3, "Tiếng Anh Thương Mại", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3606), "Khóa học tiếng Anh thương mại", (byte)0, 72, false, true, true, true, (byte)3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3606), 3000000m, null },
                    { 4, "IELTS Preparation", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3608), "Khóa học luyện thi IELTS", (byte)5, 96, false, true, true, true, (byte)4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3609), 5000000m, null },
                    { 5, "TOEIC Master", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3611), "Khóa học luyện thi TOEIC", (byte)0, 84, false, true, true, true, (byte)3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3611), 4000000m, null }
                });

            migrationBuilder.InsertData(
                table: "StudySession",
                columns: new[] { "StudySessionId", "CreatedAt", "Description", "DisplayName", "EndTime", "ModifiedAt", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3671), "Ca học sáng", "Ca 1", "09:00", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3671), "07:30" },
                    { 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3674), "Ca học sáng", "Ca 2", "10:45", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3675), "09:15" },
                    { 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3677), "Ca học chiều", "Ca 3", "15:00", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3677), "13:30" },
                    { 4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3679), "Ca học chiều", "Ca 4", "16:45", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3679), "15:15" },
                    { 5, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3681), "Ca học tối", "Ca 5", "19:30", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3681), "18:00" }
                });

            migrationBuilder.InsertData(
                table: "Tuitions",
                columns: new[] { "TuitionID", "CreatedAt", "DueDate", "Fee", "ModifiedAt", "Status", "TuitionName", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3848), new DateTime(2025, 6, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3847), 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3848), (byte)1, "Học phí tháng 1", (byte)1 },
                    { 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3852), new DateTime(2025, 7, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3851), 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3852), (byte)1, "Học phí tháng 2", (byte)1 },
                    { 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3855), new DateTime(2025, 8, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3854), 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3855), (byte)1, "Học phí tháng 3", (byte)1 },
                    { 4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3858), new DateTime(2025, 9, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3857), 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3858), (byte)1, "Học phí tháng 4", (byte)1 },
                    { 5, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3860), new DateTime(2025, 10, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3860), 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3861), (byte)1, "Học phí tháng 5", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "AvatarUrl", "CreatedAt", "DateOfBirth", "Email", "FullName", "Gender", "Introduction", "ModifiedAt", "PasswordHash", "Phone", "Role", "Status" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3368), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin User", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3381), "hashed_password", "0123456789", (byte)1, (byte)1 },
                    { 2, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3402), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher1@example.com", "Nguyễn Văn A", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3403), "hashed_password", "0123456781", (byte)2, (byte)1 },
                    { 3, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3406), new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher2@example.com", "Trần Thị B", "F", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3407), "hashed_password", "0123456782", (byte)2, (byte)1 },
                    { 4, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3410), new DateTime(2000, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "student1@example.com", "Lê Văn C", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3410), "hashed_password", "0123456783", (byte)3, (byte)1 },
                    { 5, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3412), new DateTime(2001, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "student2@example.com", "Phạm Thị D", "F", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3413), "hashed_password", "0123456784", (byte)3, (byte)1 },
                    { 6, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3417), new DateTime(2002, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "student3@example.com", "Hoàng Văn E", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3417), "hashed_password", "0123456785", (byte)3, (byte)1 },
                    { 7, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3419), new DateTime(2000, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "student4@example.com", "Đỗ Thị F", "F", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3419), "hashed_password", "0123456786", (byte)3, (byte)1 },
                    { 8, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3421), new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "student5@example.com", "Vũ Văn G", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3421), "hashed_password", "0123456787", (byte)3, (byte)1 },
                    { 9, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3423), new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "student6@example.com", "Ngô Thị H", "F", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3423), "hashed_password", "0123456788", (byte)3, (byte)1 },
                    { 10, null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3427), new DateTime(2000, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "student7@example.com", "Đặng Văn I", "M", null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3428), "hashed_password", "0123456790", (byte)3, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "ClassName", "CourseID", "CreatedAt", "EndDate", "MaxStudents", "ModifiedAt", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "Basic English A1", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3634), new DateTime(2025, 8, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3633), 20, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3635), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3633), (byte)1 },
                    { 2, "Basic English A2", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3639), new DateTime(2025, 9, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3638), 20, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3639), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3638), (byte)1 },
                    { 3, "Conversation English B1", 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 10, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3642), 15, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3643), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3641), (byte)1 },
                    { 4, "Business English B2", 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3645), new DateTime(2025, 11, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3645), 15, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3646), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3644), (byte)1 },
                    { 5, "IELTS Preparation C1", 4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3649), new DateTime(2025, 12, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3648), 10, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3649), new DateTime(2025, 6, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3647), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonID", "ContentUrl", "CourseID", "CreatedAt", "Description", "Duration", "IsPublished", "LessonName", "ModifiedAt", "Position", "ThumbnailUrl", "Type" },
                values: new object[,]
                {
                    { 1, "lesson1.mp4", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3770), "Giới thiệu về khóa học", 45, true, "Bài 1: Giới thiệu", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3771), 1, null, (byte)1 },
                    { 2, "lesson2.mp4", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3775), "Cách chào hỏi trong tiếng Anh", 45, true, "Bài 2: Chào hỏi", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3776), 2, null, (byte)1 },
                    { 3, "lesson3.mp4", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3778), "Học về số đếm trong tiếng Anh", 45, true, "Bài 3: Số đếm", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3779), 3, null, (byte)1 },
                    { 4, "lesson4.mp4", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3781), "Bài tập thực hành", 45, true, "Bài 4: Thực hành", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3781), 4, null, (byte)2 },
                    { 5, "lesson5.mp4", 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3783), "Bài kiểm tra kiến thức", 45, true, "Bài 5: Kiểm tra", new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3784), 5, null, (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "CreatedAt", "EnrollmentDate", "Level", "ModifiedAt", "Status" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3546), new DateTime(2024, 11, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3538), (byte)1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3546), (byte)1 },
                    { 5, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3551), new DateTime(2024, 12, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3550), (byte)2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3551), (byte)1 },
                    { 6, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3554), new DateTime(2025, 1, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3553), (byte)1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3554), (byte)1 },
                    { 7, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3557), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3555), (byte)3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3559), (byte)1 },
                    { 8, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3561), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3560), (byte)2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3561), (byte)1 },
                    { 9, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3565), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3564), (byte)1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3565), (byte)1 },
                    { 10, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3567), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3567), (byte)2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3568), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "CreatedAt", "FacebookUrl", "GoogleUrl", "InstagramUrl", "ModifiedAt", "ProfileImageUrl", "YouTubeUrl" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3508), "facebook.com/teacher1", null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3509), "teacher1.jpg", null },
                    { 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3512), "facebook.com/teacher2", null, null, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3512), "teacher2.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleID", "ClassID", "CreatedAt", "DayOfWeek", "ModifiedAt", "Notes", "Room", "SessionCode", "Status", "StudySessionId", "Subject", "TeacherID", "TimeSlot" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3704), (byte)2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3705), null, "Room 101", "MON-1", (byte)1, 1, null, 2, "07:30-09:00" },
                    { 2, 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3709), (byte)4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3709), null, "Room 101", "WED-3", (byte)1, 3, null, 2, "13:30-15:00" },
                    { 3, 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3711), (byte)3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3712), null, "Room 102", "TUE-2", (byte)1, 2, null, 3, "09:15-10:45" },
                    { 4, 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3714), (byte)5, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3714), null, "Room 102", "THU-4", (byte)1, 4, null, 3, "15:15-16:45" },
                    { 5, 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3717), (byte)6, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3717), null, "Room 103", "FRI-5", (byte)1, 5, null, 2, "18:00-19:30" }
                });

            migrationBuilder.InsertData(
                table: "StudentClassEnrollments",
                columns: new[] { "EnrollmentID", "ClassID", "CreatedAt", "EnrollmentDate", "ModifiedAt", "Status", "StudentID", "TotalTuitionDue", "TuitionPaid" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3809), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3807), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3809), (byte)1, 4, 2000000m, 1000000m },
                    { 2, 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3813), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3812), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3814), (byte)1, 5, 2000000m, 2000000m },
                    { 3, 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3817), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3815), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3817), (byte)1, 6, 2000000m, 1000000m },
                    { 4, 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3820), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3819), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3820), (byte)1, 7, 2000000m, 2000000m },
                    { 5, 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3823), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3822), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3823), (byte)1, 8, 2500000m, 1250000m }
                });

            migrationBuilder.InsertData(
                table: "StudentTuitionHistory",
                columns: new[] { "PaymentID", "AmountPaid", "CreatedAt", "EnrollmentID", "ModifiedAt", "PaymentDate", "PaymentMethod", "Status", "TransactionID", "TuitionID" },
                values: new object[,]
                {
                    { 1, 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3883), 1, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3883), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3882), (byte)1, (byte)2, null, 1 },
                    { 2, 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3887), 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3888), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3886), (byte)2, (byte)2, null, 1 },
                    { 3, 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3890), 2, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3891), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3890), (byte)2, (byte)2, null, 2 },
                    { 4, 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3893), 3, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3894), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3892), (byte)1, (byte)2, null, 1 },
                    { 5, 1000000m, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3896), 4, new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3896), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3895), (byte)3, (byte)2, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7);
        }
    }
}
