using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.DTOs.ClassDTOs;

namespace Management_Schedule_BE.Services
{
    public interface IClassService
    {
        Task<IEnumerable<DetailedClassDTO>> GetAllClassesAsync();
        Task<ClassDTO?> GetClassByIdAsync(int id);
        Task<ClassDTO> CreateClassAsync(CreateClassDTO classDto);
        Task<ClassDTO?> UpdateClassAsync(int id, UpdateClassDTO classDto);
        Task<bool> DeleteClassAsync(int id);
        Task<bool> UpdateClassStatusAsync(int id, byte status);
        Task<IEnumerable<StudentEnrolledClassDTO>> GetStudentEnrolledClassesAsync(int studentId);
        Task<IEnumerable<StudentInClassDTO>> GetStudentsInClassAsync(int classId);
        Task<IEnumerable<ClassBasicDTO>> GetAllClassBasicAsync();
        Task<bool> DeleteStudentEnrollmentAsync(int enrollmentId);
    }
} 