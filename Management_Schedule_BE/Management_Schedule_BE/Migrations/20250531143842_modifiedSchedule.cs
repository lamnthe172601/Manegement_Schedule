using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class modifiedSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4567), new DateTime(2025, 8, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4566), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4567), new DateTime(2025, 2, 28, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4572), new DateTime(2025, 9, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4571), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4573), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4576), new DateTime(2025, 10, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4575), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4576), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4579), new DateTime(2025, 11, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4578), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4579), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4583), new DateTime(2025, 12, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4582), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4583), new DateTime(2025, 6, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4531), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4536), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4539), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4542), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4545), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4678), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4679) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4685), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4688), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4690), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4693), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4693) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4645), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4646) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4649), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4652), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4655), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4657), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4755), new DateTime(2025, 2, 28, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4753), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4760), new DateTime(2025, 2, 28, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4759), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4764), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4763), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4768), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4767), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4771), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4770), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4937), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4938), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4943), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4943), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4946), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4947), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4949), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4950), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4952), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4953), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4479), new DateTime(2024, 11, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4472), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 12, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4484), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4488), new DateTime(2025, 1, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4487), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4491), new DateTime(2025, 2, 28, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4490), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4492) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4494), new DateTime(2025, 3, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4493), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4494) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4498), new DateTime(2025, 4, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4497), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4498) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4500), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4500), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4605), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4608), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4611), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4613), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4615), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4616) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4438), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4438) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4442), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4791), new DateTime(2025, 6, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4790), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4796), new DateTime(2025, 7, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4795), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4799), new DateTime(2025, 8, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4798), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4802), new DateTime(2025, 9, 30, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4801), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4802) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4805), new DateTime(2025, 10, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4804), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4805) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4280), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4306), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4346), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4347) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4349), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4352), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4352) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4358), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4360), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4362), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4364), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4367), new DateTime(2025, 5, 31, 21, 38, 42, 500, DateTimeKind.Local).AddTicks(4367) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Schedules",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3672), new DateTime(2025, 8, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3671), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3672), new DateTime(2025, 2, 28, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3677), new DateTime(2025, 9, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3676), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3678), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 10, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3680), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3684), new DateTime(2025, 11, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3683), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3685), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3683) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3688), new DateTime(2025, 12, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3687), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3688), new DateTime(2025, 6, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3635), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3636) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3640), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3643), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3646), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3649), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3817), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3822), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3825), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3827), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3830), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Subject" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3781), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3782), null });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "Subject" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3786), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3786), null });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "Subject" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3788), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3789), null });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "Subject" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3791), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3791), null });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "Subject" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3793), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3794), null });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3853), new DateTime(2025, 2, 28, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3851), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3858), new DateTime(2025, 2, 28, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3857), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3862), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3861), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3865), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3864), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3868), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3867), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3869) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3945), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3945), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3950), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3951), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3949) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3953), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3954), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3956), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3957), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3959), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3960), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3959) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3582), new DateTime(2024, 11, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3575), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3582) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3588), new DateTime(2024, 12, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3587), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3591), new DateTime(2025, 1, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3590), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3591) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3594), new DateTime(2025, 2, 28, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3593), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3596), new DateTime(2025, 3, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3596), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3600), new DateTime(2025, 4, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3599), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3602), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3602), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3603) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3709), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3743), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3745), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3746) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3748), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3750), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3545), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3549), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3889), new DateTime(2025, 6, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3888), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3894), new DateTime(2025, 7, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3893), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3897), new DateTime(2025, 8, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3896), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3900), new DateTime(2025, 9, 30, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3899), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3903), new DateTime(2025, 10, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3902), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3432), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3443) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3455), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3458), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3462), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3463) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3465), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3471), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3473), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3475), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3477), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3480), new DateTime(2025, 5, 31, 21, 35, 8, 39, DateTimeKind.Local).AddTicks(3481) });
        }
    }
}
