using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class StudySessionService : IStudySessionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudySessionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudySessionDTO>> GetAllStudySessionsAsync()
        {
            var sessions = await _context.StudySessions.ToListAsync();
            return _mapper.Map<IEnumerable<StudySessionDTO>>(sessions);
        }

        public async Task<StudySessionDTO?> GetStudySessionByIdAsync(int id)
        {
            var session = await _context.StudySessions.FindAsync(id);
            return session == null ? null : _mapper.Map<StudySessionDTO>(session);
        }

        public async Task<StudySessionDTO> CreateStudySessionAsync(CreateStudySessionDTO dto)
        {
            bool exists = await _context.StudySessions.AnyAsync(s => s.DisplayName == dto.DisplayName);
            if (exists)
                throw new Exception("Tên ca học đã tồn tại!");

            var session = _mapper.Map<StudySession>(dto);
            _context.StudySessions.Add(session);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudySessionDTO>(session);
        }

        public async Task<StudySessionDTO?> UpdateStudySessionAsync(int id, UpdateStudySessionDTO dto)
        {
            var session = await _context.StudySessions.FindAsync(id);
            if (session == null) return null;

            bool exists = await _context.StudySessions.AnyAsync(s => s.DisplayName == dto.DisplayName && s.StudySessionId != id);
            if (exists)
                throw new Exception("Tên ca học đã tồn tại!");

            _mapper.Map(dto, session);
            session.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<StudySessionDTO>(session);
        }

        public async Task<bool> DeleteStudySessionAsync(int id)
        {
            var session = await _context.StudySessions.FindAsync(id);
            if (session == null) return false;

            _context.StudySessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 