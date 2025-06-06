namespace Management_Schedule_BE.DTOs
{
    public class AssignTeacherToScheduleDTO
    {
        public int ScheduleID { get; set; }
        public int TeacherID { get; set; }
        public string? notes { get; set; } = null;
    }
} 