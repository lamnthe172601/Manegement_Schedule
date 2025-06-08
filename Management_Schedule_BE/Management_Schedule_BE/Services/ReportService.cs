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

        public async Task<DashboardAdminDTO> GetDashboardAdminAsync()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalTeachers = await _context.Teachers.CountAsync();
            var totalStudents = await _context.Students.CountAsync();
            var totalClasses = await _context.Classes.CountAsync();
            var totalCourses = await _context.Courses.CountAsync();
            var totalSchedules = await _context.Schedules.CountAsync();
            var totalActiveClasses = await _context.Classes.CountAsync(c => c.Status == 1);
            var totalActiveStudents = await _context.Students.CountAsync(s => s.Status == 1);
            var totalActiveTeachers = await _context.Teachers.CountAsync(t => t.User.Status == 1);

            return new DashboardAdminDTO
            {
                TotalUsers = totalUsers,
                TotalTeachers = totalTeachers,
                TotalStudents = totalStudents,
                TotalClasses = totalClasses,
                TotalCourses = totalCourses,
                TotalSchedules = totalSchedules,
                TotalActiveClasses = totalActiveClasses,
                TotalActiveStudents = totalActiveStudents,
                TotalActiveTeachers = totalActiveTeachers
            };
        }

        public async Task<ScheduleStatusStatisticsDTO> GetScheduleStatusStatisticsAsync()
        {
            var total = await _context.Schedules.CountAsync();
            var completed = await _context.Schedules.CountAsync(s => s.Status == 2);
            var cancelled = await _context.Schedules.CountAsync(s => s.Status == 3);
            var pending = await _context.Schedules.CountAsync(s => s.Status == 1 || s.Status == 0);
            return new ScheduleStatusStatisticsDTO
            {
                TotalSchedules = total,
                CompletedSchedules = completed,
                CancelledSchedules = cancelled,
                PendingSchedules = pending
            };
        }

        public async Task<List<TopTeacherDTO>> GetTopTeachersAsync(int top = 5)
        {
            var topTeachers = await _context.Schedules
                .Where(s => s.TeacherID != null)
                .GroupBy(s => s.TeacherID)
                .Select(g => new { TeacherID = g.Key.Value, TotalSessions = g.Count() })
                .OrderByDescending(x => x.TotalSessions)
                .Take(top)
                .ToListAsync();

            var teacherIds = topTeachers.Select(t => t.TeacherID).ToList();
            var teacherNames = await _context.Teachers
                .Where(t => teacherIds.Contains(t.TeacherID))
                .Select(t => new { t.TeacherID, t.User.FullName })
                .ToListAsync();

            return topTeachers.Select(t => new TopTeacherDTO
            {
                TeacherID = t.TeacherID,
                TeacherName = teacherNames.FirstOrDefault(n => n.TeacherID == t.TeacherID)?.FullName ?? "",
                TotalSessions = t.TotalSessions
            }).ToList();
        }

        public async Task<List<StudentDistributionByClassDTO>> GetStudentDistributionByClassAsync()
        {
            var data = await _context.Classes
                .Select(c => new StudentDistributionByClassDTO
                {
                    ClassID = c.ClassID,
                    ClassName = c.ClassName,
                    StudentCount = _context.StudentClassEnrollments.Count(e => e.ClassID == c.ClassID && e.Status == 1)
                })
                .ToListAsync();
            return data;
        }

        public async Task<List<NewApprovedStudentDTO>> GetNewApprovedStudentsAsync()
        {
            var students = await _context.Students
                .Where(s => s.User.Status == 0)
                .OrderByDescending(s => s.User.CreatedAt)
                .Take(10)
                .Select(s => new NewApprovedStudentDTO
                {
                    StudentID = s.StudentID,
                    FullName = s.User.FullName,
                    Email = s.User.Email,
                    Phone = s.User.Phone,
                    CreatedAt = s.User.CreatedAt
                })
                .ToListAsync();
            return students;
        }
    }
} 