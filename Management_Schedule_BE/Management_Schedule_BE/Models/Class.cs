using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }

        [Required]
        [StringLength(100)]
        public string ClassName { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
} 