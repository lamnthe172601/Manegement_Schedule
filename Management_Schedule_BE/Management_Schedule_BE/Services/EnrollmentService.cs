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
                .Include(c => c.Schedules)
                .FirstOrDefaultAsync(c => c.ClassID == enrollmentDto.ClassID);

            if (@class == null)
                return null;

            // Kiểm tra xem học sinh đã đăng ký vào lớp học này chưa
            var existingEnrollment = await _context.StudentClassEnrollments
                .FirstOrDefaultAsync(e => e.StudentID == studentId && e.ClassID == enrollmentDto.ClassID);

            if (existingEnrollment != null)
            {
                throw new Exception("Học sinh đã đăng ký vào lớp học này!");
            }

            // Kiểm tra số lượng học sinh trong lớp
            var currentEnrolledCount = await _context.StudentClassEnrollments
                .CountAsync(e => e.ClassID == enrollmentDto.ClassID && e.Status == 1); // Status 1 = Active

            if (currentEnrolledCount >= @class.MaxStudents)
            {
                throw new Exception("Lớp học đã đủ số lượng học sinh!");
            }

            // Kiểm tra ngày bắt đầu của lớp học
            if (@class.StartDate <= DateTime.Now)
            {
                throw new Exception("Không thể đăng ký vào lớp học đã bắt đầu!");
            }

            // Kiểm tra lịch học trùng lặp
            var studentEnrollments = await _context.StudentClassEnrollments
                .Include(e => e.Class)
                    .ThenInclude(c => c.Schedules)
                        .ThenInclude(sch => sch.StudySession)
                .Where(e => e.StudentID == studentId && e.Status == 1) // Chỉ kiểm tra các lớp đang học
                .ToListAsync();

            foreach (var enrollmentItem in studentEnrollments)
            {
                foreach (var schedule1 in enrollmentItem.Class.Schedules)
                {
                    foreach (var schedule2 in @class.Schedules)
                    {
                        // Kiểm tra trùng ngày
                        if (schedule1.Date.Date == schedule2.Date.Date)
                        {
                            // Lấy thời gian bắt đầu/kết thúc của từng ca học
                            var s1Start = TimeSpan.Parse(schedule1.StudySession.StartTime);
                            var s1End = TimeSpan.Parse(schedule1.StudySession.EndTime);
                            var s2Start = TimeSpan.Parse(schedule2.StudySession.StartTime);
                            var s2End = TimeSpan.Parse(schedule2.StudySession.EndTime);

                            // Kiểm tra trùng thời gian
                            if (s1Start < s2End && s1End > s2Start)
                            {
                                throw new Exception($"Lịch học trùng với lớp {enrollmentItem.Class.ClassName} vào ngày {schedule1.Date:dd/MM/yyyy}!");
                            }
                        }
                    }
                }
            }

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

            // Kiểm tra trạng thái hợp lệ
            if (status < 0 || status > 3)
                throw new Exception("Trạng thái không hợp lệ!");

            // Kiểm tra số tiền đã thanh toán khi cập nhật trạng thái thành Active
            if (status == 1) // Active
            {
                if (enrollment.TuitionPaid < enrollment.TotalTuitionDue)
                    throw new Exception("Không thể kích hoạt đăng ký khi chưa thanh toán đủ học phí!");
            }

            // Kiểm tra trạng thái hiện tại
            if (enrollment.Status == 3) // Cancelled
                throw new Exception("Không thể cập nhật trạng thái của đăng ký đã hủy!");

            enrollment.Status = status;
            enrollment.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 