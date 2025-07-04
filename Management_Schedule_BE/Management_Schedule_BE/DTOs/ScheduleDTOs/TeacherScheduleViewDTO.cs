using System;

namespace Management_Schedule_BE.DTOs
{
    public class TeacherScheduleViewDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int StudySessionId { get; set; }
        public string StudySessionName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Room { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public byte Status { get; set; }
    }
} 