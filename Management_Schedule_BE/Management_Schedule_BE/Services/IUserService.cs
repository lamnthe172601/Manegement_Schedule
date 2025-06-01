using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUserAsync();
        Task<UserDTO?> CreateUserAsync(UserCreateDTO userCreateDTO);
        Task<UserDTO?> UpdateUserAsync(string email, UserUpdateDTO classDto);
        Task<bool> DeleteUserAsync(string email);
        Task<UserDTO?> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<UserDTO?> GetUserByEmailAsync(string email);
        Task<UserDTO?> UpdatePasswordAsync(string email, string password);
        Task<TeachStudentProfile?> UpdateProfileAsync(string email, TeachStudentProfile profile);
    }
}
