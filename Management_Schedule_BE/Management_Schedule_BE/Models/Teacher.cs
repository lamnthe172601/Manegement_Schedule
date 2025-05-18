using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [StringLength(512)]
        public string? ProfileImageUrl { get; set; }

        [StringLength(512)]
        public string? FacebookUrl { get; set; }

        [StringLength(512)]
        public string? InstagramUrl { get; set; }

        [StringLength(512)]
        public string? GoogleUrl { get; set; }

        [StringLength(512)]
        public string? YouTubeUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("TeacherID")]
        public virtual User? User { get; set; }
        public virtual ICollection<Schedule>? Schedules { get; set; }
        public virtual ICollection<TeacherSalaryHistory>? SalaryHistory { get; set; }
    }
} 