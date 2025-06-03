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
                c.StartDate,
                c.EndDate,
                c.Status,
                c.CreatedAt,
                c.ModifiedAt,
                c.Course.CourseName
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

            c.Status = status;
            c.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}