using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;

        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync()
        {
            return await _context.Teachers
                .Select(t => new TeacherDTO
                {
                    TeacherID = t.TeacherID,
                    ProfileImageUrl = t.ProfileImageUrl,
                    FacebookUrl = t.FacebookUrl,
                    InstagramUrl = t.InstagramUrl,
                    GoogleUrl = t.GoogleUrl,
                    YouTubeUrl = t.YouTubeUrl,
                    CreatedAt = t.CreatedAt,
                    ModifiedAt = t.ModifiedAt
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TeacherDetailDTO>> GetAllTeachersWithDetailsAsync()
        {
            return await _context.Teachers
                .Include(t => t.User)
                .Select(t => new TeacherDetailDTO
                {
                    TeacherID = t.TeacherID,
                    ProfileImageUrl = t.ProfileImageUrl,
                    FacebookUrl = t.FacebookUrl,
                    InstagramUrl = t.InstagramUrl,
                    GoogleUrl = t.GoogleUrl,
                    YouTubeUrl = t.YouTubeUrl,
                    CreatedAt = t.CreatedAt,
                    ModifiedAt = t.ModifiedAt,
                    Email = t.User.Email,
                    FullName = t.User.FullName,
                    Phone = t.User.Phone,
                    Address = t.User.Address,
                    DateOfBirth = t.User.DateOfBirth,
                    Gender = t.User.Gender
                })
                .ToListAsync();
        }

        public async Task<TeacherDTO> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return null;

            return new TeacherDTO
            {
                TeacherID = teacher.TeacherID,
                ProfileImageUrl = teacher.ProfileImageUrl,
                FacebookUrl = teacher.FacebookUrl,
                InstagramUrl = teacher.InstagramUrl,
                GoogleUrl = teacher.GoogleUrl,
                YouTubeUrl = teacher.YouTubeUrl,
                CreatedAt = teacher.CreatedAt,
                ModifiedAt = teacher.ModifiedAt
            };
        }

        public async Task<TeacherDTO> CreateTeacherAsync(CreateTeacherDTO teacherDto)
        {
            var teacher = new Teacher
            {
                ProfileImageUrl = teacherDto.ProfileImageUrl,
                FacebookUrl = teacherDto.FacebookUrl,
                InstagramUrl = teacherDto.InstagramUrl,
                GoogleUrl = teacherDto.GoogleUrl,
                YouTubeUrl = teacherDto.YouTubeUrl,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return new TeacherDTO
            {
                TeacherID = teacher.TeacherID,
                ProfileImageUrl = teacher.ProfileImageUrl,
                FacebookUrl = teacher.FacebookUrl,
                InstagramUrl = teacher.InstagramUrl,
                GoogleUrl = teacher.GoogleUrl,
                YouTubeUrl = teacher.YouTubeUrl,
                CreatedAt = teacher.CreatedAt,
                ModifiedAt = teacher.ModifiedAt
            };
        }

        public async Task<TeacherDTO> UpdateTeacherAsync(int id, UpdateTeacherDTO teacherDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return null;

            teacher.ProfileImageUrl = teacherDto.ProfileImageUrl;
            teacher.FacebookUrl = teacherDto.FacebookUrl;
            teacher.InstagramUrl = teacherDto.InstagramUrl;
            teacher.GoogleUrl = teacherDto.GoogleUrl;
            teacher.YouTubeUrl = teacherDto.YouTubeUrl;
            teacher.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new TeacherDTO
            {
                TeacherID = teacher.TeacherID,
                ProfileImageUrl = teacher.ProfileImageUrl,
                FacebookUrl = teacher.FacebookUrl,
                InstagramUrl = teacher.InstagramUrl,
                GoogleUrl = teacher.GoogleUrl,
                YouTubeUrl = teacher.YouTubeUrl,
                CreatedAt = teacher.CreatedAt,
                ModifiedAt = teacher.ModifiedAt
            };
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 