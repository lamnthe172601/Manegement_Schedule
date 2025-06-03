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

        public async Task<IEnumerable<DetailedScheduleDTO>> GetAllSchedulesAsync()
        {
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .ToListAsync();

            return schedules.Select(s => new DetailedScheduleDTO(
                s.ScheduleID,
                s.ClassID,
                s.TeacherID,
                s.StudySessionId,
                s.Room,
                s.Status,
                s.Notes,
                s.CreatedAt,
                s.ModifiedAt,
                s.Date,
                s.Teacher.User.FullName,
                s.Teacher.User.AvatarUrl ?? "",
                s.StudySession.DisplayName,
                s.StudySession.StartTime,
                s.StudySession.EndTime,
                s.Class.ClassName,
                s.Class.Course.CourseName
            ));
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

        public async Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAsync(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");

            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Where(s => s.TeacherID == teacherId)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new TeacherScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();

            return schedules;
        }

        public async Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAndRangeAsync(int teacherId, DateTime? from, DateTime? to)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");
            var query = _context.Schedules
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Where(s => s.TeacherID == teacherId);
            if (from.HasValue)
                query = query.Where(s => s.Date >= from.Value);
            if (to.HasValue)
                query = query.Where(s => s.Date <= to.Value);
            var schedules = await query
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new TeacherScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();
            return schedules;
        }

        public async Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAndStatusAsync(int teacherId, byte status)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Where(s => s.TeacherID == teacherId && s.Status == status)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new TeacherScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();
            return schedules;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetSchedulesByDateAsync(DateTime date)
        {
            var schedules = await _context.Schedules
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                .Where(s => s.Date.Date == date.Date)
                .OrderBy(s => s.StudySession.StartTime)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy học sinh");

            var classIds = await _context.StudentClassEnrollments
                .Where(e => e.StudentID == studentId && e.Status == 1)
                .Select(e => e.ClassID)
                .ToListAsync();

            var schedules = await _context.Schedules
                .Where(s => classIds.Contains(s.ClassID))
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new StudentScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    TeacherName = s.Teacher.User.FullName,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();

            return schedules;
        }

        public async Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndRangeAsync(int studentId, DateTime? from, DateTime? to)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy học sinh");

            var classIds = await _context.StudentClassEnrollments
                .Where(e => e.StudentID == studentId && e.Status == 1)
                .Select(e => e.ClassID)
                .ToListAsync();

            var query = _context.Schedules
                .Where(s => classIds.Contains(s.ClassID));

            if (from.HasValue)
                query = query.Where(s => s.Date >= from.Value);
            if (to.HasValue)
                query = query.Where(s => s.Date <= to.Value);

            var schedules = await query
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new StudentScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    TeacherName = s.Teacher.User.FullName,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();

            return schedules;
        }

        public async Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndStatusAsync(int studentId, byte status)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy học sinh");

            var classIds = await _context.StudentClassEnrollments
                .Where(e => e.StudentID == studentId && e.Status == 1)
                .Select(e => e.ClassID)
                .ToListAsync();

            var schedules = await _context.Schedules
                .Where(s => classIds.Contains(s.ClassID) && s.Status == status)
                .Include(s => s.StudySession)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StudySession.StartTime)
                .Select(s => new StudentScheduleViewDTO
                {
                    ClassID = s.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    StudySessionId = s.StudySessionId,
                    StudySessionName = s.StudySession.DisplayName,
                    StartTime = s.StudySession.StartTime,
                    EndTime = s.StudySession.EndTime,
                    TeacherName = s.Teacher.User.FullName,
                    Room = s.Room,
                    Date = s.Date
                })
                .ToListAsync();

            return schedules;
        }
    }
} 