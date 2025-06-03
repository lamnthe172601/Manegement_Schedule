using System;

namespace Management_Schedule_BE.DTOs
{
    public class StudentScheduleViewDTO
    {
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public string StudySessionName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TeacherName { get; set; }
        public string Room { get; set; }
    }
} 