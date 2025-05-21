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
        public async Task<UserDTO> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            if(GetUserByEmailAsync(userCreateDTO.Email) == null)
            {
                var user = _mapper.Map<User>(userCreateDTO);
                user.PasswordHash = PasswordHassing.ComputeSha256Hash(user.PasswordHash);
                _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var passwordHas = PasswordHassing.ComputeSha256Hash(password);
            var u = await _context.Users.FirstOrDefaultAsync(x => x.Email == email & x.PasswordHash == passwordHas);
            return u == null ? null : _mapper.Map<UserDTO>(u);
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            var u = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return u == null ? null : _mapper.Map<UserDTO>(u);
        }

        public Task<UserDTO?> UpdateUserAsync(int id, UserUpdateDTO classDto)
        {
            throw new NotImplementedException();
        }
    }
}
