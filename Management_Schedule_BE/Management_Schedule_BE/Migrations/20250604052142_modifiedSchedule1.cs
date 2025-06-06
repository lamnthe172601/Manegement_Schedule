using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class modifiedSchedule1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsSelling = table.Column<bool>(type: "bit", nullable: false),
                    IsComingSoon = table.Column<bool>(type: "bit", nullable: false),
                    IsPro = table.Column<bool>(type: "bit", nullable: false),
                    IsCompletable = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "StudySession",
                columns: table => new
                {
                    StudySessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySession", x => x.StudySessionId);
                });

            migrationBuilder.CreateTable(
                name: "Tuitions",
                columns: table => new
                {
                    TuitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuitions", x => x.TuitionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    MaxStudents = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    GoogleUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    YouTubeUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassEnrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTuitionDue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TuitionPaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassEnrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_StudentClassEnrollments_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClassEnrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: true),
                    StudySessionId = table.Column<int>(type: "int", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedules_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_StudySession_StudySessionId",
                        column: x => x.StudySessionId,
                        principalTable: "StudySession",
                        principalColumn: "StudySessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateTable(
                name: "StudentTuitionHistory",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    TuitionID = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTuitionHistory", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_StudentTuitionHistory_StudentClassEnrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "StudentClassEnrollments",
                        principalColumn: "EnrollmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTuitionHistory_Tuitions_TuitionID",
                        column: x => x.TuitionID,
                        principalTable: "Tuitions",
                        principalColumn: "TuitionID");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "CreatedAt", "Description", "DiscountPercent", "Duration", "IsComingSoon", "IsCompletable", "IsPro", "IsSelling", "Level", "ModifiedAt", "Price", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh Cơ Bản", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(914), "Khóa học tiếng Anh cho người mới bắt đầu", (byte)0, 48, false, true, false, true, (byte)1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(915), 2000000m, null },
                    { 2, "Tiếng Anh Giao Tiếp", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(924), "Khóa học tiếng Anh giao tiếp cơ bản", (byte)10, 60, false, true, false, true, (byte)2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(924), 2500000m, null },
                    { 3, "Tiếng Anh Thương Mại", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(926), "Khóa học tiếng Anh thương mại", (byte)0, 72, false, true, true, true, (byte)3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(927), 3000000m, null },
                    { 4, "IELTS Preparation", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(929), "Khóa học luyện thi IELTS", (byte)5, 96, false, true, true, true, (byte)4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(929), 5000000m, null },
                    { 5, "TOEIC Master", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(932), "Khóa học luyện thi TOEIC", (byte)0, 84, false, true, true, true, (byte)3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(932), 4000000m, null }
                });

            migrationBuilder.InsertData(
                table: "StudySession",
                columns: new[] { "StudySessionId", "CreatedAt", "Description", "DisplayName", "EndTime", "ModifiedAt", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(994), "Ca học sáng", "Ca 1", "09:00", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(994), "07:30" },
                    { 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(998), "Ca học sáng", "Ca 2", "10:45", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(998), "09:15" },
                    { 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1000), "Ca học chiều", "Ca 3", "15:00", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1000), "13:30" },
                    { 4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1002), "Ca học chiều", "Ca 4", "16:45", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1002), "15:15" },
                    { 5, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1004), "Ca học tối", "Ca 5", "19:30", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1005), "18:00" }
                });

            migrationBuilder.InsertData(
                table: "Tuitions",
                columns: new[] { "TuitionID", "CreatedAt", "DueDate", "Fee", "ModifiedAt", "Status", "TuitionName", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1170), new DateTime(2025, 7, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1169), 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1171), (byte)1, "Học phí tháng 1", (byte)1 },
                    { 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1174), new DateTime(2025, 8, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1174), 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1175), (byte)1, "Học phí tháng 2", (byte)1 },
                    { 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1177), new DateTime(2025, 9, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1177), 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1178), (byte)1, "Học phí tháng 3", (byte)1 },
                    { 4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1180), new DateTime(2025, 10, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1179), 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1180), (byte)1, "Học phí tháng 4", (byte)1 },
                    { 5, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1183), new DateTime(2025, 11, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1182), 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1183), (byte)1, "Học phí tháng 5", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "AvatarUrl", "CreatedAt", "DateOfBirth", "Email", "FullName", "Gender", "Introduction", "ModifiedAt", "PasswordHash", "Phone", "Role", "Status" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(728), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin User", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(740), "hashed_password", "0123456789", (byte)1, (byte)1 },
                    { 2, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(751), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher1@example.com", "Nguyễn Văn A", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(751), "hashed_password", "0123456781", (byte)2, (byte)1 },
                    { 3, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(754), new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher2@example.com", "Trần Thị B", "F", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(754), "hashed_password", "0123456782", (byte)2, (byte)1 },
                    { 4, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(756), new DateTime(2000, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "student1@example.com", "Lê Văn C", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(757), "hashed_password", "0123456783", (byte)3, (byte)1 },
                    { 5, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(758), new DateTime(2001, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "student2@example.com", "Phạm Thị D", "F", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(759), "hashed_password", "0123456784", (byte)3, (byte)1 },
                    { 6, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(763), new DateTime(2002, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "student3@example.com", "Hoàng Văn E", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(763), "hashed_password", "0123456785", (byte)3, (byte)1 },
                    { 7, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(765), new DateTime(2000, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "student4@example.com", "Đỗ Thị F", "F", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(765), "hashed_password", "0123456786", (byte)3, (byte)1 },
                    { 8, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(767), new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "student5@example.com", "Vũ Văn G", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(767), "hashed_password", "0123456787", (byte)3, (byte)1 },
                    { 9, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(769), new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "student6@example.com", "Ngô Thị H", "F", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(769), "hashed_password", "0123456788", (byte)3, (byte)1 },
                    { 10, null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(772), new DateTime(2000, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "student7@example.com", "Đặng Văn I", "M", null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(772), "hashed_password", "0123456790", (byte)3, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "ClassName", "CourseID", "CreatedAt", "EndDate", "MaxStudents", "ModifiedAt", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "Basic English A1", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(956), new DateTime(2025, 9, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(955), 20, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(956), new DateTime(2025, 3, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(954), (byte)1 },
                    { 2, "Basic English A2", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(961), new DateTime(2025, 10, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(961), 20, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(962), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(960), (byte)1 },
                    { 3, "Conversation English B1", 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(965), new DateTime(2025, 11, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(964), 15, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(965), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(964), (byte)1 },
                    { 4, "Business English B2", 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(968), new DateTime(2025, 12, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(967), 15, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(968), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(967), (byte)1 },
                    { 5, "IELTS Preparation C1", 4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(971), new DateTime(2026, 1, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(971), 10, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(972), new DateTime(2025, 7, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(970), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonID", "ContentUrl", "CourseID", "CreatedAt", "Description", "Duration", "IsPublished", "LessonName", "ModifiedAt", "Position", "ThumbnailUrl", "Type" },
                values: new object[,]
                {
                    { 1, "lesson1.mp4", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1096), "Giới thiệu về khóa học", 45, true, "Bài 1: Giới thiệu", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1096), 1, null, (byte)1 },
                    { 2, "lesson2.mp4", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1100), "Cách chào hỏi trong tiếng Anh", 45, true, "Bài 2: Chào hỏi", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1100), 2, null, (byte)1 },
                    { 3, "lesson3.mp4", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1102), "Học về số đếm trong tiếng Anh", 45, true, "Bài 3: Số đếm", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1103), 3, null, (byte)1 },
                    { 4, "lesson4.mp4", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1105), "Bài tập thực hành", 45, true, "Bài 4: Thực hành", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1105), 4, null, (byte)2 },
                    { 5, "lesson5.mp4", 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1107), "Bài kiểm tra kiến thức", 45, true, "Bài 5: Kiểm tra", new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1108), 5, null, (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "CreatedAt", "EnrollmentDate", "Level", "ModifiedAt", "Status" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(865), new DateTime(2024, 12, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(859), (byte)1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(865), (byte)1 },
                    { 5, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(869), new DateTime(2025, 1, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(868), (byte)2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(870), (byte)1 },
                    { 6, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(872), new DateTime(2025, 2, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(871), (byte)1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(872), (byte)1 },
                    { 7, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(875), new DateTime(2025, 3, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(874), (byte)3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(875), (byte)1 },
                    { 8, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(877), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(877), (byte)2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(878), (byte)1 },
                    { 9, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(880), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(880), (byte)1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(881), (byte)1 },
                    { 10, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(883), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(882), (byte)2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(883), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "CreatedAt", "FacebookUrl", "GoogleUrl", "InstagramUrl", "ModifiedAt", "ProfileImageUrl", "YouTubeUrl" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(831), "facebook.com/teacher1", null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(832), "teacher1.jpg", null },
                    { 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(835), "facebook.com/teacher2", null, null, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(835), "teacher2.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleID", "ClassID", "CreatedAt", "Date", "ModifiedAt", "Notes", "Room", "Status", "StudySessionId", "TeacherID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1039), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1039), null, "Room 01", (byte)1, 1, 2 },
                    { 2, 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1043), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1044), null, "Room 01", (byte)1, 3, 2 },
                    { 3, 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1071), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1072), null, "Room 02", (byte)1, 2, 3 },
                    { 4, 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1074), new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1074), null, "Room 02", (byte)1, 4, 3 },
                    { 5, 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1076), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1077), null, "Room 03", (byte)1, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentClassEnrollments",
                columns: new[] { "EnrollmentID", "ClassID", "CreatedAt", "EnrollmentDate", "ModifiedAt", "Status", "StudentID", "TotalTuitionDue", "TuitionPaid" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1132), new DateTime(2025, 3, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1130), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1132), (byte)1, 4, 2000000m, 1000000m },
                    { 2, 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1137), new DateTime(2025, 3, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1136), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1137), (byte)1, 5, 2000000m, 2000000m },
                    { 3, 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1140), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1139), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1140), (byte)1, 6, 2000000m, 1000000m },
                    { 4, 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1143), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1142), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1144), (byte)1, 7, 2000000m, 2000000m },
                    { 5, 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1146), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1145), new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1147), (byte)1, 8, 2500000m, 1250000m }
                });

            migrationBuilder.InsertData(
                table: "StudentTuitionHistory",
                columns: new[] { "PaymentID", "AmountPaid", "CreatedAt", "EnrollmentID", "ModifiedAt", "PaymentDate", "PaymentMethod", "Status", "TransactionID", "TuitionID" },
                values: new object[,]
                {
                    { 1, 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1245), 1, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1246), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1244), (byte)1, (byte)2, null, 1 },
                    { 2, 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1251), 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1252), new DateTime(2025, 4, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1250), (byte)2, (byte)2, null, 1 },
                    { 3, 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1254), 2, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1255), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1253), (byte)2, (byte)2, null, 2 },
                    { 4, 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1257), 3, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1257), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1256), (byte)1, (byte)2, null, 1 },
                    { 5, 1000000m, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1260), 4, new DateTime(2025, 6, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1260), new DateTime(2025, 5, 4, 12, 21, 40, 18, DateTimeKind.Local).AddTicks(1259), (byte)3, (byte)2, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassName",
                table: "Classes",
                column: "ClassName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseID",
                table: "Classes",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseID",
                table: "Lessons",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassID",
                table: "Schedules",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StudySessionId",
                table: "Schedules",
                column: "StudySessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherID",
                table: "Schedules",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassEnrollments_ClassID",
                table: "StudentClassEnrollments",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassEnrollments_StudentID",
                table: "StudentClassEnrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTuitionHistory_EnrollmentID",
                table: "StudentTuitionHistory",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTuitionHistory_TuitionID",
                table: "StudentTuitionHistory",
                column: "TuitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tuitions_TuitionName",
                table: "Tuitions",
                column: "TuitionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "StudentTuitionHistory");

            migrationBuilder.DropTable(
                name: "StudySession");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "StudentClassEnrollments");

            migrationBuilder.DropTable(
                name: "Tuitions");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
