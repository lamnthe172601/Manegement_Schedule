using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public int? ClassID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StudentID")]
        public virtual User? User { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class? Class { get; set; }

        public virtual ICollection<StudentTuitionHistory>? TuitionHistory { get; set; }
    }
} 