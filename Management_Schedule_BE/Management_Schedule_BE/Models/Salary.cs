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
        public decimal BasicSalary { get; set; }

        [Required]
        public decimal Bonus { get; set; }

        [Required]
        public byte Type { get; set; } // 1=Monthly, 2=Hourly

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public byte Status { get; set; } // 1=Active, 2=Inactive

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<TeacherSalaryHistory>? SalaryHistory { get; set; }
    }
} 