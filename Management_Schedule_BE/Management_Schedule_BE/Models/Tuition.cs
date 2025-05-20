using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Tuitions")]
    public class Tuition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TuitionID { get; set; }

        [Required]
        [StringLength(100)]
        public string TuitionName { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Required]
        public byte Type { get; set; } // 1=Monthly, 2=Course, 3=Other

        public DateTime? DueDate { get; set; }

        [Required]
        public byte Status { get; set; } // 1=Active, 2=Inactive

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<StudentTuitionHistory>? TuitionHistory { get; set; }
    }
} 