using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Helpers;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDTO CreateUser(UserCreateDTO userCreateDTO)
        {
            bool exitsEmail = GetUserByEmailAsync(userCreateDTO.Email);

            if (exitsEmail == false)
            {
                var user = _mapper.Map<User>(userCreateDTO);
                user.PasswordHash = PasswordHassing.ComputeSha256Hash(user.PasswordHash);
                _context.Users.Add(user);
                _context.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        private bool GetUserByEmailAsync(string email)
        {
            try
            {
                var result = _context.Users.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                return result != null;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<UserDTO> GetAllUser()
        {
            var users = _context.Users.ToList();
            if (users == null || users.Count == 0)
            {
                return Enumerable.Empty<UserDTO>();
            }
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUserByEmailAndPassword(string email, string password)
        {
            var passwordHas = PasswordHassing.ComputeSha256Hash(password);
            var u = _context.Users.SingleOrDefault(x => x.Email == email & x.PasswordHash == passwordHas);
            return u == null ? null : _mapper.Map<UserDTO>(u);
        }

        public UserDTO UpdateUser(string email, UserUpdateDTO classDto)
        {
            bool exitsEmail = GetUserByEmailAsync(email);
            if (exitsEmail != false)
            {
                var user = _mapper.Map<User>(classDto);
                _context.Users.Update(user);
                _context.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public bool DeleteUser(string email)
        {
            bool exitsEmail = GetUserByEmailAsync(email);
            if (exitsEmail)
            {
                var result = _context.Users.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                _context.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
