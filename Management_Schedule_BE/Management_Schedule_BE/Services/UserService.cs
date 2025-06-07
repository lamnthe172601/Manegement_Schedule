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

                //write function upload file
                await UpLoadFileImgAsync(user, userCreateDTO.AvatarUrl, "/avatar-mac-dinh-4.jpg");

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

        private async Task UpLoadFileImgAsync(User user, IFormFile? avatarUrl, string avtDefault)
        {
            try
            {
                if (avatarUrl != null && avatarUrl.Length > 0)
                {
                    user.AvatarUrl = await _storageService.UploadFileAsync(avatarUrl);
                }
                else
                {
                    var defaultAvatar = _configuration["R2:PublicUrlBase"] + avtDefault;
                    user.AvatarUrl = defaultAvatar;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Upload avatar error: " + ex.ToString());
                throw; 
            }
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
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.PasswordHash == passwordHash);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdateUserAsync(string email, UserUpdateDTO classDto)
        {
            bool existsEmail = await CheckUserExistsByEmailAsync(email);
            if (existsEmail)
            {
                var userFind = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

                _mapper.Map(classDto, userFind);
                await UpLoadFileImgAsync(userFind, classDto.AvatarUrl, "/avatar-mac-dinh-4.jpg");

                _context.Users.Update(userFind);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(userFind);
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
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdatePasswordAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
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
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                await UpLoadFileImgAsync(user, profile.AvatarUrl, "/avatar-mac-dinh-4.jpg");

                _mapper.Map(profile, user);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<TeachStudentProfile>(user);
            }
            return null;
        }
    }
}
