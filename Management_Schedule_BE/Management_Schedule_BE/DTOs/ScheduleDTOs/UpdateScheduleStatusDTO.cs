public record UpdateScheduleStatusDTO(
    byte Status, // 1=Active, 2=Completed, 3=Cancelled
    string? Notes
); 