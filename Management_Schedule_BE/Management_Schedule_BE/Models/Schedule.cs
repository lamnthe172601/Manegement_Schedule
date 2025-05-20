using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleID { get; set; }

        [Required]
        public int ClassID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        public int? StudySessionId { get; set; }

        [Required]
        [StringLength(20)]
        public string SessionCode { get; set; }

        [Required]
        public byte DayOfWeek { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeSlot { get; set; }

        [StringLength(255)]
        public string? Subject { get; set; }

        [Required]
        [StringLength(50)]
        public string Room { get; set; }

        [Required]
        public byte Status { get; set; } // 1=Scheduled, 2=Completed, 3=Cancelled

        public string? Notes { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ClassID")]
        public virtual Class? Class { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher? Teacher { get; set; }

        [ForeignKey("StudySessionId")]
        public virtual StudySession? SessionCodeNavigation { get; set; }
    }
} 