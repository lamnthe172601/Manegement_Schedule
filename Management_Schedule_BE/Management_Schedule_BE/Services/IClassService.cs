using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDTO>> GetAllClassesAsync();
        Task<ClassDTO?> GetClassByIdAsync(int id);
        Task<ClassDTO> CreateClassAsync(CreateClassDTO classDto);
        Task<ClassDTO?> UpdateClassAsync(int id, UpdateClassDTO classDto);
        Task<bool> DeleteClassAsync(int id);
        Task<bool> UpdateClassStatusAsync(int id, byte status);
    }
} 