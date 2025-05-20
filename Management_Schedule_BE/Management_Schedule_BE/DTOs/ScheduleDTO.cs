using System;

namespace Management_Schedule_BE.DTOs
{
    public record ScheduleDTO(
        int ScheduleID,
        int ClassID,
        int TeacherID,
        int? StudySessionId,
        string SessionCode,
        byte DayOfWeek,
        string TimeSlot,
        string? Subject,
        string Room,
        byte Status,
        string? Notes,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateScheduleDTO(
        int ClassID,
        int TeacherID,
        int? StudySessionId,
        string SessionCode,
        byte DayOfWeek,
        string TimeSlot,
        string? Subject,
        string Room,
        byte Status,
        string? Notes
    );

    public record UpdateScheduleDTO(
        int TeacherID,
        int? StudySessionId,
        string SessionCode,
        byte DayOfWeek,
        string TimeSlot,
        string? Subject,
        string Room,
        byte Status,
        string? Notes
    );
} 