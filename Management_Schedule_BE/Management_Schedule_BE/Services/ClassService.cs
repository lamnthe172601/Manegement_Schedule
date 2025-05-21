using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
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

        public async Task<IEnumerable<ClassDTO>> GetAllClassesAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            return _mapper.Map<IEnumerable<ClassDTO>>(classes);
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

            bool exists = await _context.Classes.AnyAsync(x => x.ClassName == classDto.ClassName && x.CourseID == c.CourseID && x.ClassID != id);
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
    }
}