using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync()
        {
            var schedules = await _context.Schedules.ToListAsync();
            return _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<ScheduleDTO?> GetScheduleByIdAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            return schedule == null ? null : _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> CreateScheduleAsync(CreateScheduleDTO dto)
        {
            bool exists = await _context.Schedules.AnyAsync(s => s.SessionCode == dto.SessionCode && s.ClassID == dto.ClassID);
            if (exists)
                throw new Exception("Mã ca học đã tồn tại trong lớp này!");

            var schedule = _mapper.Map<Schedule>(dto);
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO?> UpdateScheduleAsync(int id, UpdateScheduleDTO dto)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return null;

            bool exists = await _context.Schedules.AnyAsync(s => s.SessionCode == dto.SessionCode && s.ClassID == schedule.ClassID && s.ScheduleID != id);
            if (exists)
                throw new Exception("Mã ca học đã tồn tại trong lớp này!");

            _mapper.Map(dto, schedule);
            schedule.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 