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
        public string? TuitionName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fee { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<StudentTuitionHistory>? StudentTuitionHistories { get; set; }
    }
} 