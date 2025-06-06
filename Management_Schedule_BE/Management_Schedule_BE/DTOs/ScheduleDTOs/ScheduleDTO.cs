using Management_Schedule_BE.Models;
using System;

namespace Management_Schedule_BE.DTOs
{
    public record ScheduleDTO(
        int ScheduleID,
        int ClassID,
        int? TeacherID,
        int StudySessionId,
        string Room,
        byte Status,
        string? Notes,
        DateTime CreatedAt,
        DateTime ModifiedAt,
        DateTime Date
        
    );

    public record CreateScheduleDTO(
        int ClassID,
        int TeacherID,
        int StudySessionId,
        string Room,
        byte Status,
        string? Notes,
        DateTime Date
    );

    public record UpdateScheduleDTO(
        int TeacherID,
        int StudySessionId,
        string Room,
        byte Status,
        string? Notes,
        DateTime Date
    );

    public record UpdateScheduleStatusDTO(
        byte Status // 1=Active, 2=Completed, 3=Cancelled
    );
} 