using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUser();
       
        UserDTO CreateUser(UserCreateDTO userCreateDTO);
        UserDTO UpdateUser(string email, UserUpdateDTO classDto);
        bool DeleteUser(string email);
        UserDTO GetUserByEmailAndPassword(string email, string password);
        UserDTO GetUserByEmail(string email);
    }
}
