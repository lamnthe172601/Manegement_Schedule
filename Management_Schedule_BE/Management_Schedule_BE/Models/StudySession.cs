using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("StudySession ")]
    public class StudySession
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudySessionId { get; set; }

        [Required]
        [StringLength(100)]
        public string? DisplayName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Schedule>? Schedules { get; set; }

       
    }
} 