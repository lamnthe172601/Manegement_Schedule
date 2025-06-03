using Management_Schedule_BE.Models;
using System;

namespace Management_Schedule_BE.DTOs
{
    public record ClassDTO(
        int ClassID,
        string ClassName,
        int CourseID,
        int MaxStudents,
        DateTime StartDate,
        DateTime? EndDate,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateClassDTO(
        string ClassName,
        int CourseID,
        int MaxStudents,
        DateTime StartDate,
        DateTime? EndDate,
        byte Status
    );

    public record UpdateClassDTO(
        string ClassName,
        int MaxStudents,
        DateTime StartDate,
        DateTime? EndDate,
        byte Status
    );

    public record UpdateClassStatusDTO(
        byte Status // 1=Active, 2=Completed, 3=Cancelled
    );
} 