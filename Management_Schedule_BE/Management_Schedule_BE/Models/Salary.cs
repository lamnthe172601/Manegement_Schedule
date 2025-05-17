using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Salaries")]
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryID { get; set; }

        [Required]
        [StringLength(100)]
        public string SalaryName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal BasicSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Bonus { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<TeacherSalaryHistory> TeacherSalaryHistories { get; set; }
    }
} 