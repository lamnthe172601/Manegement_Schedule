using System;

namespace Management_Schedule_BE.DTOs
{
    public record DetailedScheduleDTO(
        int ScheduleID,
        int ClassID,
        int? TeacherID,
        int StudySessionId,
        string Room,
        byte Status,
        string? Notes,
        DateTime CreatedAt,
        DateTime ModifiedAt,
        DateTime Date,
        string TeacherName,
        string TeacherImage,
        string StudySessionDisplayName,
        string StartTime,
        string EndTime,
        string ClassName,
        string CourseName
    );
} 