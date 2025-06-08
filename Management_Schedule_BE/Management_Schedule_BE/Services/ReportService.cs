using AutoMapper;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReportService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherScheduleReportDTO> GetTeacherScheduleReportAsync(int teacherId)
        {
            var teacher = await _context.Teachers.Include(t => t.User).FirstOrDefaultAsync(t => t.TeacherID == teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");

            var teacherName = teacher.User != null ? teacher.User.FullName : "";

            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.TeacherID == teacherId)
                .ToListAsync();

            var report = new TeacherScheduleReportDTO
            {
                TeacherID = teacher.TeacherID,
                TeacherName = teacherName,
                TotalSessions = schedules.Count,
                CompletedSessions = schedules.Count(s => s.Status == 2),
                CancelledSessions = schedules.Count(s => s.Status == 3),
                Schedules = _mapper.Map<List<ScheduleDTO>>(schedules)
            };

            return report;
        }

        public async Task<ClassScheduleReportDTO> GetClassScheduleReportAsync(int classId)
        {
            var classEntity = await _context.Classes.FindAsync(classId);
            if (classEntity == null)
                throw new Exception("Không tìm thấy lớp học");

            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.ClassID == classId)
                .ToListAsync();

            var report = new ClassScheduleReportDTO
            {
                ClassID = classEntity.ClassID,
                ClassName = classEntity.ClassName,
                TotalSessions = schedules.Count,
                CompletedSessions = schedules.Count(s => s.Status == 2),
                CancelledSessions = schedules.Count(s => s.Status == 3),
                Schedules = _mapper.Map<List<ScheduleDTO>>(schedules)
            };

            return report;
        }

        public async Task<RoomScheduleReportDTO> GetRoomScheduleReportAsync(string room)
        {
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.Room == room)
                .ToListAsync();

            var report = new RoomScheduleReportDTO
            {
                Room = room,
                TotalSessions = schedules.Count,
                CompletedSessions = schedules.Count(s => s.Status == 2),
                CancelledSessions = schedules.Count(s => s.Status == 3),
                Schedules = _mapper.Map<List<ScheduleDTO>>(schedules)
            };

            return report;
        }

        public async Task<DailyScheduleReportDTO> GetDailyScheduleReportAsync()
        {
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .ToListAsync();

            var report = new DailyScheduleReportDTO
            {
                TotalSessions = schedules.Count,
                CompletedSessions = schedules.Count(s => s.Status == 2),
                CancelledSessions = schedules.Count(s => s.Status == 3),
                Schedules = _mapper.Map<List<ScheduleDTO>>(schedules)
            };

            return report;
        }

        public async Task<TeacherStatisticsDTO> GetTeacherStatisticsAsync(int teacherId)
        {
            var teacher = await _context.Teachers.Include(t => t.User).FirstOrDefaultAsync(t => t.TeacherID == teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");

            var teacherName = teacher.User != null ? teacher.User.FullName : "";

            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.TeacherID == teacherId)
                .ToListAsync();

            var roomUsage = schedules
                .GroupBy(s => s.Room)
                .ToDictionary(g => g.Key, g => g.Count());

            var dayDistribution = schedules
                .GroupBy(s => s.Date.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.Count());

            var totalTeachingHours = schedules
                .Where(s => s.Status != 3)
                .Count();

            var totalClasses = schedules
                .Select(s => s.ClassID)
                .Distinct()
                .Count();

            var statistics = new TeacherStatisticsDTO
            {
                TeacherID = teacher.TeacherID,
                TeacherName = teacherName,
                TotalTeachingHours = totalTeachingHours,
                TotalClasses = totalClasses,
                RoomUsage = roomUsage,
                DayDistribution = dayDistribution
            };

            return statistics;
        }

        public async Task<RoomStatisticsDTO> GetRoomStatisticsAsync(string room)
        {
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.Room == room)
                .ToListAsync();

            var teacherDistribution = schedules
                .GroupBy(s => s.TeacherID)
                .ToDictionary(g => g.Key, g => g.Count());

            var dayDistribution = schedules
                .GroupBy(s => s.Date.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.Count());

            var totalTeachingHours = schedules
                .Where(s => s.Status != 3)
                .Count();

            var statistics = new RoomStatisticsDTO
            {
                Room = room,
                TotalSessions = schedules.Count,
                TotalTeachingHours = totalTeachingHours,
                TeacherDistribution = teacherDistribution,
                DayDistribution = dayDistribution
            };

            return statistics;
        }
    }
} 