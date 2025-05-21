using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUserAsync();
        Task<UserDTO?> GetUserByEmailAsync(string email);
        Task<UserDTO> CreateUserAsync(UserCreateDTO userCreateDTO);
        Task<UserDTO?> UpdateUserAsync(int id, UserUpdateDTO classDto);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDTO?> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
