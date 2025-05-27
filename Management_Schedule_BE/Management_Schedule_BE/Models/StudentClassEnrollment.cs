using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("StudentClassEnrollments")]
    public class StudentClassEnrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int ClassID { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalTuitionDue { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TuitionPaid { get; set; } = 0;

        [Required]
        public byte Status { get; set; } // 0=Pending, 1=Active, 2=Completed, 3=Cancelled

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StudentID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class? Class { get; set; }

        public virtual ICollection<StudentTuitionHistory>? TuitionHistory { get; set; }
    }
} 