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

        [Required]
        public byte Level { get; set; } // 1=Beginner, 2=Elementary, 3=Intermediate, 4=Upper Intermediate, 5=Advanced

        [Required]
        public DateTime? EnrollmentDate { get; set; }

        [Required]
        public byte Status { get; set; } // 1=Active, 2=Inactive, 3=OnLeave

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StudentID")]
        public virtual User? User { get; set; }

        public virtual ICollection<StudentClassEnrollment>? ClassEnrollments { get; set; }
    }
} 