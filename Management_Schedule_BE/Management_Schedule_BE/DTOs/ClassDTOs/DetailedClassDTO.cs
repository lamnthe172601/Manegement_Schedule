using System;

namespace Management_Schedule_BE.DTOs
{
    public record DetailedClassDTO(
        int ClassID,
        string ClassName,
        int CourseID,
        int MaxStudents,
        DateTime StartDate,
        DateTime? EndDate,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt,
        string CourseName,
        int Duration,
        bool IsHaveSchedule,
        string Note,
        int EnrolledStudents
    );
} 