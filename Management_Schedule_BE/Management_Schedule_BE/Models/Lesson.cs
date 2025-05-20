using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonID { get; set; }

        [Required]
        [StringLength(255)]
        public string LessonName { get; set; }

        public string? Description { get; set; }

        [Required]
        [StringLength(512)]
        public string ContentUrl { get; set; }

        [StringLength(512)]
        public string? ThumbnailUrl { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public int Duration { get; set; } // Duration in minutes

        [Required]
        public byte Type { get; set; } // 1=Theory, 2=Practice, 3=Quiz

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CourseID")]
        public virtual Course? Course { get; set; }
    }
} 