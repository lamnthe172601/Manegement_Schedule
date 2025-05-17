using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Required]
        [StringLength(255)]
        public string CourseName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public byte DiscountPercent { get; set; }

        public string? Description { get; set; }

        [StringLength(512)]
        public string? ThumbnailUrl { get; set; }

        [Required]
        public bool IsPro { get; set; }

        [Required]
        public bool IsComingSoon { get; set; }

        [Required]
        public bool IsSelling { get; set; }

        [Required]
        public bool IsCompletable { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
} 