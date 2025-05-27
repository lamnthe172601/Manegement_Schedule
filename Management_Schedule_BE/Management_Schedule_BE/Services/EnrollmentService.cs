using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EnrollmentDTO> CreateEnrollmentAsync(int studentId, CreateEnrollmentDTO enrollmentDto)
        {
            var @class = await _context.Classes
                .Include(c => c.Course)
                .FirstOrDefaultAsync(c => c.ClassID == enrollmentDto.ClassID);

            if (@class == null)
                return null;

            var enrollment = new StudentClassEnrollment
            {
                StudentID = studentId,
                ClassID = enrollmentDto.ClassID,
                EnrollmentDate = DateTime.Now,
                TotalTuitionDue = @class.Course.Price,
                TuitionPaid = 0,
                Status = 0 // Pending
            };

            _context.StudentClassEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return new EnrollmentDTO(
                enrollment.EnrollmentID,
                enrollment.StudentID,
                enrollment.ClassID,
                enrollment.EnrollmentDate,
                enrollment.TotalTuitionDue,
                enrollment.TuitionPaid,
                enrollment.Status,
                enrollment.CreatedAt,
                enrollment.ModifiedAt
            );
        }

        public async Task<IEnumerable<EnrollmentDetailDTO>> GetStudentEnrollmentsAsync(int studentId)
        {
            var enrollments = await _context.StudentClassEnrollments
                .Include(e => e.Student)
                .ThenInclude(s => s.User)
                .Include(e => e.Class)
                .ThenInclude(c => c.Course)
                .Where(e => e.StudentID == studentId)
                .Select(e => new EnrollmentDetailDTO(
                    e.EnrollmentID,
                    e.StudentID,
                    e.Student.User.FullName,
                    e.ClassID,
                    e.Class.ClassName,
                    e.Class.Course.CourseName,
                    e.EnrollmentDate,
                    e.TotalTuitionDue,
                    e.TuitionPaid,
                    e.TotalTuitionDue - e.TuitionPaid,
                    e.Status,
                    e.CreatedAt,
                    e.ModifiedAt
                ))
                .ToListAsync();

            return enrollments;
        }

        public async Task<EnrollmentDetailDTO?> GetEnrollmentByIdAsync(int enrollmentId)
        {
            var enrollment = await _context.StudentClassEnrollments
                .Include(e => e.Student)
                .ThenInclude(s => s.User)
                .Include(e => e.Class)
                .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(e => e.EnrollmentID == enrollmentId);

            if (enrollment == null)
                return null;

            return new EnrollmentDetailDTO(
                enrollment.EnrollmentID,
                enrollment.StudentID,
                enrollment.Student.User.FullName,
                enrollment.ClassID,
                enrollment.Class.ClassName,
                enrollment.Class.Course.CourseName,
                enrollment.EnrollmentDate,
                enrollment.TotalTuitionDue,
                enrollment.TuitionPaid,
                enrollment.TotalTuitionDue - enrollment.TuitionPaid,
                enrollment.Status,
                enrollment.CreatedAt,
                enrollment.ModifiedAt
            );
        }

        public async Task<bool> UpdateEnrollmentStatusAsync(int enrollmentId, byte status)
        {
            var enrollment = await _context.StudentClassEnrollments.FindAsync(enrollmentId);
            if (enrollment == null)
                return false;

            enrollment.Status = status;
            enrollment.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 