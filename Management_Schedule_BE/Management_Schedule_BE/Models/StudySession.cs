using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("StudySession")]
    public class StudySession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudySessionId { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(50)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EndTime { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Schedule>? Schedules { get; set; }
    }
} 