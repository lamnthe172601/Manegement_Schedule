using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields : Migration
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
                    Prerequisites = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryID);
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
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Students_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID");
                    table.ForeignKey(
                        name: "FK_Students_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    StudySessionId = table.Column<int>(type: "int", nullable: true),
                    SessionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DayOfWeek = table.Column<byte>(type: "tinyint", nullable: false),
                    TimeSlot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                        principalColumn: "StudySessionId");
                    table.ForeignKey(
                        name: "FK_Schedules_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSalaryHistory",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    SalaryID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_TeacherSalaryHistory", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_TeacherSalaryHistory_Salaries_SalaryID",
                        column: x => x.SalaryID,
                        principalTable: "Salaries",
                        principalColumn: "SalaryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSalaryHistory_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTuitionHistory",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TuitionID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_StudentTuitionHistory_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTuitionHistory_Tuitions_TuitionID",
                        column: x => x.TuitionID,
                        principalTable: "Tuitions",
                        principalColumn: "TuitionID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Salaries_SalaryName",
                table: "Salaries",
                column: "SalaryName",
                unique: true);

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
                name: "IX_Students_ClassID",
                table: "Students",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTuitionHistory_StudentID",
                table: "StudentTuitionHistory",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTuitionHistory_TuitionID",
                table: "StudentTuitionHistory",
                column: "TuitionID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSalaryHistory_SalaryID",
                table: "TeacherSalaryHistory",
                column: "SalaryID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSalaryHistory_TeacherID",
                table: "TeacherSalaryHistory",
                column: "TeacherID");

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
                name: "TeacherSalaryHistory");

            migrationBuilder.DropTable(
                name: "StudySession");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tuitions");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
