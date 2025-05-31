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

                // Bổ sung: Nếu là student thì tạo bản ghi student
                if (user.Role == 3) // 3 = Student
                {
                    var student = new Student
                    {
                        StudentID = user.UserID, // Giả sử StudentID trùng với UserID
                        Level = 0, // mặc định Beginner
                        EnrollmentDate = DateTime.Now,
                        Status = 1, // Active
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    _context.Students.Add(student);
                    _context.SaveChanges();
                }
                // Nếu là teacher thì tạo bản ghi teacher
                else if (user.Role == 2) // 2 = Teacher
                {
                    var teacher = new Teacher
                    {
                        TeacherID = user.UserID, // Giả sử TeacherID trùng với UserID
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    _context.Teachers.Add(teacher);
                    _context.SaveChanges();
                }
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

        //public UserDTO UpdateUser(string email, UserUpdateDTO classDto)
        //{
        //    bool exitsEmail = GetUserByEmailAsync(email);
        //    if (exitsEmail != false)
        //    {
        //        var user = _mapper.Map<User>(classDto);
        //        _context.Users.Update(user);
        //        _context.SaveChanges();
        //        return _mapper.Map<UserDTO>(user);
        //    }
        //    return null;
        //}
        public UserDTO? UpdateUser(string email, UserUpdateDTO updateDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            // Chỉ cập nhật các trường nếu được truyền
            if (!string.IsNullOrEmpty(updateDto.FullName)) user.FullName = updateDto.FullName;
            if (!string.IsNullOrEmpty(updateDto.Gender)) user.Gender = updateDto.Gender;
            if (updateDto.DateOfBirth.HasValue) user.DateOfBirth = updateDto.DateOfBirth.Value;
            if (!string.IsNullOrEmpty(updateDto.Address)) user.Address = updateDto.Address;
            if (!string.IsNullOrEmpty(updateDto.Phone)) user.Phone = updateDto.Phone;
            if (!string.IsNullOrEmpty(updateDto.Introduction)) user.Introduction = updateDto.Introduction;
            if (!string.IsNullOrEmpty(updateDto.AvatarUrl)) user.AvatarUrl = updateDto.AvatarUrl;
            user.ModifiedAt = updateDto.ModifiedAt;

            // Nếu bạn cho phép cập nhật Role/Status:
            if (updateDto.Role != 0) user.Role = updateDto.Role;
            if (updateDto.Status != 0) user.Status = updateDto.Status;

            _context.SaveChanges();

            return _mapper.Map<UserDTO>(user);
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
