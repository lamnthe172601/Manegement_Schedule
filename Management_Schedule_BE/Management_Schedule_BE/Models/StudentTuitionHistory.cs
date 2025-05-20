using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("StudentTuitionHistory")]
    public class StudentTuitionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int TuitionID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AmountPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public byte PaymentMethod { get; set; } // 1=Cash, 2=Bank Transfer, 3=Credit Card

        [StringLength(100)]
        public string? TransactionID { get; set; }

        [Required]
        public byte Status { get; set; } // 1=Pending, 2=Completed, 3=Failed

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StudentID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("TuitionID")]
        public virtual Tuition? Tuition { get; set; }
    }
} 