using System;

namespace Management_Schedule_BE.DTOs
{
    public record StudentEnrolledClassDTO(
        string ClassName,
        int CourseID,
        string CourseName,
        int MaxStudents,
        int EnrolledStudents,
        DateTime StartDate,
        DateTime? EndDate,
        int Duration,
        decimal Price,
        byte Level
    );
} 