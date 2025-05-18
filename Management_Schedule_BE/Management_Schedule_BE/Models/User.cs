using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Schedule_BE.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Email { get; set; }

        [Required]
        [StringLength(512)]
        public string? PasswordHash { get; set; }

        [Required]
        public byte Role { get; set; } // 1=Admin, 2=Teacher, 3=Student

        [StringLength(255)]
        public string? FullName { get; set; }

        [StringLength(1)]
        public string? Gender { get; set; } // M, F, O

        public DateTime? DateOfBirth { get; set; }

        [StringLength(512)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        public string? Introduction { get; set; }

        [StringLength(512)]
        public string? AvatarUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Teacher? Teacher { get; set; }
        public virtual Student? Student { get; set; }
    }
} 