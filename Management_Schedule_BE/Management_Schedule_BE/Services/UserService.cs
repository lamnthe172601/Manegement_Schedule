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
        public UserDTO CreateUserAsync(UserCreateDTO userCreateDTO)
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
              var result =  _context.Users.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                return result != null;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<UserDTO> GetAllUserAsync()
        {
            var users =  _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var passwordHas = PasswordHassing.ComputeSha256Hash(password);
            var u = _context.Users.FirstOrDefaultAsync(x => x.Email == email & x.PasswordHash == passwordHas);
            return u == null ? null : _mapper.Map<UserDTO>(u);
        }

        public UserDTO UpdateUserAsync(int id, UserUpdateDTO classDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
