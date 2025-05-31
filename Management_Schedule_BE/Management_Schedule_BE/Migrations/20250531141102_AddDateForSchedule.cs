using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management_Schedule_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddDateForSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6475), new DateTime(2025, 8, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6474), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6475), new DateTime(2025, 2, 28, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6480), new DateTime(2025, 9, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6479), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6480), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6478) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6483), new DateTime(2025, 10, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6483), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6484), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6487), new DateTime(2025, 11, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6486), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6487), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6490), new DateTime(2025, 12, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6489), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6490), new DateTime(2025, 6, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6489) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6436), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6441), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6444), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6446), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6449), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6591), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6592) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6595), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6598), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6599) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6601), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6603), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Date", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6553), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6554), "Room 01" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Date", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6558), new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6558), "Room 01" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Date", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6561), new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6561), "Room 02" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Date", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6564), new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6564), "Room 02" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Date", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6567), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6567), "Room 03" });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6727), new DateTime(2025, 2, 28, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6726), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6728) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6732), new DateTime(2025, 2, 28, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6731), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6736), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6735), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6739), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6738), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6739) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6742), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6741), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6840), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6841), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6845), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6846), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6848), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6849), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6851), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6852), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6854), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6855), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6385), new DateTime(2024, 11, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6378), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6386) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 12, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6390), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6394), new DateTime(2025, 1, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6393), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6395) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6397), new DateTime(2025, 2, 28, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6396), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6397) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6400), new DateTime(2025, 3, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6399), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6403), new DateTime(2025, 4, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6402), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6406), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6405), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6512), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6516), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6518), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6521), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6523), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6348), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6349) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6352), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6803), new DateTime(2025, 6, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6802), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6807), new DateTime(2025, 7, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6807), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6810), new DateTime(2025, 8, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6810), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6813), new DateTime(2025, 9, 30, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6813), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6816), new DateTime(2025, 10, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6815), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6178), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6205), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6206) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6208), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6208) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6211), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6213), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6213) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6218), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6219), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6221), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6223), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6224) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6259), new DateTime(2025, 5, 31, 21, 10, 59, 707, DateTimeKind.Local).AddTicks(6260) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3634), new DateTime(2025, 8, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3633), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3635), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3633) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3639), new DateTime(2025, 9, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3638), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3639), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3638) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 10, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3643), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3645), new DateTime(2025, 11, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3645), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3646), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3649), new DateTime(2025, 12, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3648), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3649), new DateTime(2025, 6, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3598), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3598) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3603), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3603) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3606), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3608), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3611), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3611) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3770), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3771) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3775), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3778), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3781), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3783), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3704), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3705), "Room 101" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3709), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3709), "Room 101" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3711), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3712), "Room 102" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3714), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3714), "Room 102" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "Room" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3717), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3717), "Room 103" });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3809), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3807), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3813), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3812), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3817), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3815), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3817) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3820), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3819), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "StudentClassEnrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3823), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3822), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3883), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3883), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3887), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3888), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3886) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3890), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3891), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3893), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3894), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3892) });

            migrationBuilder.UpdateData(
                table: "StudentTuitionHistory",
                keyColumn: "PaymentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt", "PaymentDate" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3896), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3896), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3546), new DateTime(2024, 11, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3538), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3551), new DateTime(2024, 12, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3550), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3554), new DateTime(2025, 1, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3553), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3554) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3557), new DateTime(2025, 2, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3555), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3559) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3561), new DateTime(2025, 3, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3560), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3561) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3565), new DateTime(2025, 4, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3564), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EnrollmentDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3567), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3567), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3671), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3671) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3674), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3677), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3679), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "StudySession",
                keyColumn: "StudySessionId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3508), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3512), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3512) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3848), new DateTime(2025, 6, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3847), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3848) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3852), new DateTime(2025, 7, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3851), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3855), new DateTime(2025, 8, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3854), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3858), new DateTime(2025, 9, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3857), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "Tuitions",
                keyColumn: "TuitionID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DueDate", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3860), new DateTime(2025, 10, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3860), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3368), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3402), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3406), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3410), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3412), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3417), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3417) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3419), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3421), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3421) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3423), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3427), new DateTime(2025, 5, 28, 10, 12, 41, 483, DateTimeKind.Local).AddTicks(3428) });
        }
    }
}
