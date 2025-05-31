using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course == null ? null : _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDto)
        {
            bool exists = await _context.Courses.AnyAsync(c => c.CourseName == courseDto.CourseName);
            if (exists)
                throw new Exception("Tên khóa học đã tồn tại!");

            var course = _mapper.Map<Course>(courseDto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO?> UpdateCourseAsync(int id, UpdateCourseDTO courseDto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;

            bool exists = await _context.Courses.AnyAsync(c => c.CourseName == courseDto.CourseName && c.CourseID != id);
            if (exists)
                throw new Exception("Tên khóa học đã tồn tại!");

            _mapper.Map(courseDto, course);
            course.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCourseSellingStatusAsync(int id, bool isSelling)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            course.IsSelling = isSelling;
            course.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 