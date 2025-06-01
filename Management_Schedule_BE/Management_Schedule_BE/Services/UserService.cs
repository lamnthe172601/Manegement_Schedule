using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Helpers;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Services.SystemSerivce.StoreService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IMapper mapper, IStorageService storageService, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
            _configuration = configuration;
        }

        public async Task<UserDTO?> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            bool existsEmail = await CheckUserExistsByEmailAsync(userCreateDTO.Email);

            if (!existsEmail)
            {
                var user = _mapper.Map<User>(userCreateDTO);
                user.PasswordHash = PasswordHassing.ComputeSha256Hash(user.PasswordHash);

                if (userCreateDTO.AvatarUrl != null && userCreateDTO.AvatarUrl.Length > 0)
                {
                    user.AvatarUrl = await _storageService.UploadFileAsync(userCreateDTO.AvatarUrl);
                }
                else
                {
                    
                    var defaultAvatar = _configuration["R2:PublicUrlBase"] + "/avatar-mac-dinh-4.jpg";
                    user.AvatarUrl = defaultAvatar;
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // Bổ sung: Nếu là student thì tạo bản ghi student
                if (user.Role == 3) // 3 = Student
                {
                    var student = new Student
                    {
                        StudentID = user.UserID,
                        Level = 0,
                        EnrollmentDate = DateTime.Now,
                        Status = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    await _context.Students.AddAsync(student);
                    await _context.SaveChangesAsync();
                }
                // Nếu là teacher thì tạo bản ghi teacher
                else if (user.Role == 2) // 2 = Teacher
                {
                    var teacher = new Teacher
                    {
                        TeacherID = user.UserID,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    await _context.Teachers.AddAsync(teacher);
                    await _context.SaveChangesAsync();
                }
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        private async Task<bool> CheckUserExistsByEmailAsync(string email)
        {
            try
            {
                var result = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
                return result != null;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || !users.Any())
            {
                return Enumerable.Empty<UserDTO>();
            }
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var passwordHash = PasswordHassing.ComputeSha256Hash(password);
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email && x.PasswordHash == passwordHash);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdateUserAsync(string email, UserUpdateDTO classDto)
        {
            bool existsEmail = await CheckUserExistsByEmailAsync(email);
            if (existsEmail)
            {
                var user = _mapper.Map<User>(classDto);

                if (classDto.AvatarUrl != null && classDto.AvatarUrl.Length > 0)
                {
                    user.AvatarUrl = await _storageService.UploadFileAsync(classDto.AvatarUrl);
                }
                else
                {
                    var defaultAvatar = _configuration["R2:PublicUrlBase"] + "/avatar-mac-dinh-4.jpg";
                    user.AvatarUrl = defaultAvatar;
                }

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            bool existsEmail = await CheckUserExistsByEmailAsync(email);
            if (existsEmail)
            {
                var result = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
                if (result != null)
                {
                    result.Status = 3;
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdatePasswordAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                user.PasswordHash = PasswordHassing.ComputeSha256Hash(password);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public async Task<TeachStudentProfile?> UpdateProfileAsync(string email, TeachStudentProfile profile)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                if (profile.AvatarUrl != null && profile.AvatarUrl.Length > 0)
                {
                    user.AvatarUrl = await _storageService.UploadFileAsync(profile.AvatarUrl);
                }
                else
                {
                    var defaultAvatar = _configuration["R2:PublicUrlBase"] + "/avatar-mac-dinh-4.jpg";
                    user.AvatarUrl = defaultAvatar;
                }

                _mapper.Map(profile, user);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<TeachStudentProfile>(user);
            }
            return null;
        }
    }
}
