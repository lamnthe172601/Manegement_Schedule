namespace Management_Schedule_BE.DTOs
{
    public class TeacherClassDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int MaxStudents { get; set; }
        public DateTime StartDate { get; set; }
       
        public byte Status { get; set; }
    }
} 