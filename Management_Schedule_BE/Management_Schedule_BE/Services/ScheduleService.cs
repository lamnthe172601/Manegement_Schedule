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
        private static readonly string[] ValidRooms = { "Room 01", "Room 02", "Room 03" };

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
            // Kiểm tra phòng học hợp lệ
            if (!ValidRooms.Contains(dto.Room))
                throw new Exception("Phòng học không hợp lệ. Chỉ được sử dụng Room 01, Room 02 hoặc Room 03");

            // Kiểm tra trùng lịch giáo viên
            bool teacherConflict = await _context.Schedules.AnyAsync(s => 
                s.TeacherID == dto.TeacherID && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3);

            if (teacherConflict)
                throw new Exception("Giáo viên đã có lịch dạy trong khung giờ này!");

            // Kiểm tra trùng phòng học
            bool roomConflict = await _context.Schedules.AnyAsync(s => 
                s.Room == dto.Room && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3);

            if (roomConflict)
                throw new Exception("Phòng học đã được sử dụng trong khung giờ này!");

            // Kiểm tra trùng lịch lớp học
            bool classConflict = await _context.Schedules.AnyAsync(s => 
                s.ClassID == dto.ClassID && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3);

            if (classConflict)
                throw new Exception("Lớp học đã có lịch học trong khung giờ này!");

            var schedule = _mapper.Map<Schedule>(dto);
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO?> UpdateScheduleAsync(int id, UpdateScheduleDTO dto)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return null;

            // Kiểm tra phòng học hợp lệ
            if (!ValidRooms.Contains(dto.Room))
                throw new Exception("Phòng học không hợp lệ. Chỉ được sử dụng Room 01, Room 02 hoặc Room 03");

            // Kiểm tra trùng lịch giáo viên
            bool teacherConflict = await _context.Schedules.AnyAsync(s => 
                s.TeacherID == dto.TeacherID && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3 &&
                s.ScheduleID != id);

            if (teacherConflict)
                throw new Exception("Giáo viên đã có lịch dạy trong khung giờ này!");

            // Kiểm tra trùng phòng học
            bool roomConflict = await _context.Schedules.AnyAsync(s => 
                s.Room == dto.Room && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3 &&
                s.ScheduleID != id);

            if (roomConflict)
                throw new Exception("Phòng học đã được sử dụng trong khung giờ này!");

            // Kiểm tra trùng lịch lớp học
            bool classConflict = await _context.Schedules.AnyAsync(s => 
                s.ClassID == schedule.ClassID && 
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                s.Status != 3 &&
                s.ScheduleID != id);

            if (classConflict)
                throw new Exception("Lớp học đã có lịch học trong khung giờ này!");

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

        public async Task<bool> UpdateScheduleStatusAsync(int id, byte status)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            schedule.Status = status;
            schedule.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 