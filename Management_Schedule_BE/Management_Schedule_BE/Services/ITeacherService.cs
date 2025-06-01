using System.Collections.Generic;
using System.Threading.Tasks;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync();
        Task<IEnumerable<TeacherDetailDTO>> GetAllTeachersWithDetailsAsync();
        Task<TeacherDTO> GetTeacherByIdAsync(int id);
        Task<TeacherDTO> CreateTeacherAsync(CreateTeacherDTO teacherDto);
        Task<TeacherDTO> UpdateTeacherAsync(int id, UpdateTeacherDTO teacherDto);
        Task<bool> DeleteTeacherAsync(int id);
    }
} 