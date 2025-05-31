using System;

namespace Management_Schedule_BE.DTOs
{
    public record EnrollmentDTO(
        int EnrollmentID,
        int StudentID,
        int ClassID,
        DateTime EnrollmentDate,
        decimal TotalTuitionDue,
        decimal TuitionPaid,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateEnrollmentDTO(
        int ClassID
    );

    public record EnrollmentDetailDTO(
        int EnrollmentID,
        int StudentID,
        string StudentName,
        int ClassID,
        string ClassName,
        string CourseName,
        DateTime EnrollmentDate,
        decimal TotalTuitionDue,
        decimal TuitionPaid,
        decimal RemainingAmount,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record UpdateEnrollmentStatusDTO(
        byte Status // 0=Pending, 1=Active, 2=Completed, 3=Cancelled
    );
} 