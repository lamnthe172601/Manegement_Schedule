using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.DTOs.ClassDTOs;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Services;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetailedClassDTO>> GetAllClassesAsync()
        {
            var classes = await _context.Classes
                .Include(c => c.Course)
                .ToListAsync();

            return classes.Select(c => new DetailedClassDTO(
                c.ClassID,
                c.ClassName,
                c.CourseID,
                c.MaxStudents,
                c.Course.CourseName,
                c.Course.Duration,
                c.StartDate,
                c.EndDate,
                c.Status,
                c.CreatedAt,
                c.ModifiedAt
                
            ));
        }

        public async Task<ClassDTO?> GetClassByIdAsync(int id)
        {
            var c = await _context.Classes.FindAsync(id);
            return c == null ? null : _mapper.Map<ClassDTO>(c);
        }

        public async Task<ClassDTO> CreateClassAsync(CreateClassDTO classDto)
        {
            bool exists = await _context.Classes.AnyAsync(c => c.ClassName == classDto.ClassName && c.CourseID == classDto.CourseID);
            if (exists)
                throw new Exception("Tên lớp đã tồn tại trong khóa học này!");

            var c = _mapper.Map<Class>(classDto);
            _context.Classes.Add(c);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClassDTO>(c);
        }

        public async Task<ClassDTO?> UpdateClassAsync(int id, UpdateClassDTO classDto)
        {
            var c = await _context.Classes.FindAsync(id);
            if (c == null) return null;

            bool exists = await _context.Classes.AnyAsync(c => c.ClassName == classDto.ClassName && c.CourseID == c.CourseID && c.ClassID != id);
            if (exists)
                throw new Exception("Tên lớp đã tồn tại trong khóa học này!");

            _mapper.Map(classDto, c);
            c.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<ClassDTO>(c);
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var c = await _context.Classes.FindAsync(id);
            if (c == null) return false;

            _context.Classes.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateClassStatusAsync(int id, byte status)
        {
            var c = await _context.Classes.FindAsync(id);
            if (c == null) return false;

            // Kiểm tra trạng thái hợp lệ
            if (status < 0 || status > 3)
                throw new Exception("Trạng thái không hợp lệ!");

            // Kiểm tra số học sinh đã đăng ký khi cập nhật trạng thái
            if (status == 1) // Active
            {
                var enrolledCount = await _context.StudentClassEnrollments
                    .CountAsync(e => e.ClassID == id && e.Status == 1);
                
                if (enrolledCount > c.MaxStudents)
                    throw new Exception("Số lượng học sinh đã đăng ký vượt quá số lượng tối đa cho phép!");
            }

            // Kiểm tra trạng thái hiện tại
            if (c.Status == 3) // Cancelled
                throw new Exception("Không thể cập nhật trạng thái của lớp đã hủy!");

            c.Status = status;
            c.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentEnrolledClassDTO>> GetStudentEnrolledClassesAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy học sinh");

            var enrolledClasses = await _context.StudentClassEnrollments
                .Include(e => e.Class)
                    .ThenInclude(c => c.Course)
                .Where(e => e.StudentID == studentId && e.Status == 1) // Status 1 = Active
                .Select(e => new
                {
                    Class = e.Class,
                    Course = e.Class.Course,
                    EnrolledCount = _context.StudentClassEnrollments
                        .Count(en => en.ClassID == e.ClassID && en.Status == 1)
                })
                .Select(x => new StudentEnrolledClassDTO(
                    x.Class.ClassName,
                    x.Class.CourseID,
                    x.Course.CourseName,
                    x.Class.MaxStudents,
                    x.EnrolledCount,
                    x.Class.StartDate,
                    x.Class.EndDate,
                    x.Course.Duration,
                    x.Course.Price,
                    x.Course.Level
                ))
                .ToListAsync();

            return enrolledClasses;
        }
    }
}