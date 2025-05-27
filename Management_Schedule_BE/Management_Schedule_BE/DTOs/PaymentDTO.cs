using System;

namespace Management_Schedule_BE.DTOs
{
    public record PaymentDTO(
        int PaymentID,
        int EnrollmentID,
        int? TuitionID,
        decimal AmountPaid,
        DateTime PaymentDate,
        byte PaymentMethod,
        string? TransactionID,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateVNPayPaymentDTO(
        int EnrollmentID,
        decimal Amount,
        string OrderInfo
    );

    public record VNPayReturnDTO(
        string RspCode,
        string Message
    );

    public record PaymentHistoryDTO(
        int PaymentID,
        int EnrollmentID,
        string ClassName,
        string CourseName,
        decimal AmountPaid,
        DateTime PaymentDate,
        byte PaymentMethod,
        string? TransactionID,
        byte Status
    );
} 