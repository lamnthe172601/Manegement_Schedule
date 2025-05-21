using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUserAsync();
       
        UserDTO CreateUserAsync(UserCreateDTO userCreateDTO);
        UserDTO UpdateUserAsync(int id, UserUpdateDTO classDto);
        bool DeleteUserAsync(int id);
        UserDTO GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
