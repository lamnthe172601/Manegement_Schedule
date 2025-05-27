using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDTO> CreateEnrollmentAsync(int studentId, CreateEnrollmentDTO enrollmentDto);
        Task<IEnumerable<EnrollmentDetailDTO>> GetStudentEnrollmentsAsync(int studentId);
        Task<EnrollmentDetailDTO?> GetEnrollmentByIdAsync(int enrollmentId);
        Task<bool> UpdateEnrollmentStatusAsync(int enrollmentId, byte status);
    }
} 