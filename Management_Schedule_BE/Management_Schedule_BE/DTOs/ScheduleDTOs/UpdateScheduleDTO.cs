public record UpdateScheduleDTO(
    int ClassID,
    int TeacherID,
    int StudySessionId,
    string Room,
    byte Status,
    string? Notes,
    DateTime Date
); 