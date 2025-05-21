using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LessonService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonDTO>> GetAllLessonsAsync()
        {
            var lessons = await _context.Lessons.ToListAsync();
            return _mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        public async Task<LessonDTO?> GetLessonByIdAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            return lesson == null ? null : _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<LessonDTO> CreateLessonAsync(CreateLessonDTO lessonDto)
        {
            bool exists = await _context.Lessons.AnyAsync(l => l.LessonName == lessonDto.LessonName && l.CourseID == lessonDto.CourseID);
            if (exists)
                throw new Exception("Tên bài học đã tồn tại trong khóa học này!");

            var lesson = _mapper.Map<Lesson>(lessonDto);
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<LessonDTO?> UpdateLessonAsync(int id, UpdateLessonDTO lessonDto)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null) return null;

            bool exists = await _context.Lessons.AnyAsync(l => l.LessonName == lessonDto.LessonName && l.CourseID == lesson.CourseID && l.LessonID != id);
            if (exists)
                throw new Exception("Tên bài học đã tồn tại trong khóa học này!");

            _mapper.Map(lessonDto, lesson);
            lesson.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null) return false;

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 