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
                s.Teacher?.User?.FullName ?? "",
                s.Teacher?.User?.AvatarUrl ?? "",
                s.StudySession?.DisplayName ?? "",
                s.StudySession?.StartTime ?? "",
                s.StudySession?.EndTime ?? "",
                s.Class?.ClassName ?? "",
                s.Class?.Course?.CourseName ?? ""
            ));
        }

        public async Task<ScheduleDTO?> GetScheduleByIdAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            return schedule == null ? null : _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> CreateScheduleAsync(CreateScheduleDTO dto)
        {
            // Kiểm tra lớp học tồn tại
            var classEntity = await _context.Classes
                .Include(c => c.Course)
                .FirstOrDefaultAsync(c => c.ClassID == dto.ClassID);
            if (classEntity == null)
                throw new Exception("Không tìm thấy lớp học");

            // Kiểm tra giáo viên tồn tại
            var teacher = await _context.Teachers.FindAsync(dto.TeacherID);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");

            // Kiểm tra ca học tồn tại
            var studySession = await _context.StudySessions.FindAsync(dto.StudySessionId);
            if (studySession == null)
                throw new Exception("Không tìm thấy ca học");

            // Kiểm tra phòng học hợp lệ
            if (!ValidRooms.Contains(dto.Room))
                throw new Exception("Phòng học không hợp lệ. Chỉ được sử dụng Room 01, Room 02 hoặc Room 03");

            // Kiểm tra trùng lịch học
            var isScheduleConflict = await _context.Schedules
                .AnyAsync(s => s.Date.Date == dto.Date.Date 
                    && s.StudySessionId == dto.StudySessionId 
                    && s.Room == dto.Room.Trim() 
                    && s.Status != 3); // 3 = Cancelled
            if (isScheduleConflict)
                throw new Exception("Phòng học đã được sử dụng trong ca học này");

            // Kiểm tra giáo viên có lịch trùng không
            var isTeacherBusy = await _context.Schedules
                .AnyAsync(s => s.Date.Date == dto.Date.Date 
                    && s.StudySessionId == dto.StudySessionId 
                    && s.TeacherID == dto.TeacherID 
                    && s.Status != 3);
            if (isTeacherBusy)
                throw new Exception("Giáo viên đã có lịch dạy trong ca học này");

            // Lấy danh sách các buổi học của lớp
            var classSchedules = await _context.Schedules
                .Where(s => s.ClassID == dto.ClassID)
                .OrderBy(s => s.Date)
                .ToListAsync();

            // Đếm số buổi học đã hoàn thành (status = 2)
            var completedSchedules = classSchedules.Count(s => s.Status == 2);
            
            // Đếm số buổi học đang active hoặc pending (status = 0 hoặc 1)
            var activeSchedules = classSchedules.Count(s => s.Status == 0 || s.Status == 1);

            // Kiểm tra tổng số buổi học
            if (completedSchedules + activeSchedules >= classEntity.Course.Duration)
                throw new Exception($"Lớp đã có đủ {classEntity.Course.Duration} buổi học, không thể tạo thêm!");

            // Kiểm tra điều kiện tạo lịch học bù
            if (dto.Status == 1) // Nếu là lịch học bù (status = 1)
            {
                // Kiểm tra xem có buổi học nào bị hủy không
                var cancelledSchedules = classSchedules.Where(s => s.Status == 3).ToList();
                if (!cancelledSchedules.Any())
                    throw new Exception("Không thể tạo lịch học bù khi chưa có buổi học nào bị hủy!");

                // Kiểm tra xem ngày tạo lịch học bù có sau ngày của buổi học bị hủy không
                var lastCancelledSchedule = cancelledSchedules.OrderByDescending(s => s.Date).First();
                if (dto.Date.Date <= lastCancelledSchedule.Date.Date)
                    throw new Exception("Lịch học bù phải được tạo sau ngày của buổi học bị hủy!");

                // Kiểm tra số lượng lịch học bù đã tạo
                var makeupSchedules = classSchedules.Count(s => s.Status == 1);
                if (makeupSchedules >= cancelledSchedules.Count)
                    throw new Exception("Đã tạo đủ số lịch học bù cho các buổi bị hủy!");
            }

            // Kiểm tra ngày học có hợp lệ không
            if (dto.Date.Date < classEntity.StartDate.Date)
                throw new Exception("Ngày học không được trước ngày bắt đầu của lớp");
            if (dto.Date.Date > classEntity.EndDate?.Date)
                throw new Exception("Ngày học không được sau ngày kết thúc của lớp");

            // Tạo lịch học mới
            var schedule = new Schedule
            {
                ClassID = dto.ClassID,
                TeacherID = dto.TeacherID,
                StudySessionId = dto.StudySessionId,
                Room = dto.Room,
                Status = dto.Status,
                Notes = dto.Notes,
                Date = dto.Date,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return new ScheduleDTO(
                schedule.ScheduleID,
                schedule.ClassID,
                schedule.TeacherID,
                schedule.StudySessionId,
                schedule.Room,
                schedule.Status,
                schedule.Notes,
                schedule.CreatedAt,
                schedule.ModifiedAt,
                schedule.Date
            );
        }

        public async Task<ScheduleDTO?> UpdateScheduleAsync(int id, UpdateScheduleDTO dto)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return null;

            // Kiểm tra phòng học hợp lệ
            if (!ValidRooms.Contains(dto.Room))
                throw new Exception("Phòng học không hợp lệ. Chỉ được sử dụng Room 01, Room 02 hoặc Room 03");

            // Kiểm tra trùng lịch
            var existingSchedule = await _context.Schedules
                .FirstOrDefaultAsync(s =>
                    s.ScheduleID != id && // Loại trừ lịch hiện tại
                s.Date == dto.Date && 
                s.StudySessionId == dto.StudySessionId && 
                    (s.ClassID == dto.ClassID || s.TeacherID == dto.TeacherID || s.Room == dto.Room));

            if (existingSchedule != null)
            {
                if (existingSchedule.ClassID == dto.ClassID)
                    throw new Exception("Lớp học này đã có lịch học trong ca học này!");
                if (existingSchedule.TeacherID == dto.TeacherID)
                    throw new Exception("Giáo viên này đã có lịch dạy trong ca học này!");
                if (existingSchedule.Room == dto.Room)
                    throw new Exception("Phòng học này đã được sử dụng trong ca học này!");
            }

            // Kiểm tra trạng thái
            if (schedule.Status == 3) // 3 = Cancelled
                throw new Exception("Không thể cập nhật lịch đã hủy!");

            // Cập nhật thông tin
            schedule.ClassID = dto.ClassID;
            schedule.TeacherID = dto.TeacherID;
            schedule.StudySessionId = dto.StudySessionId;
            schedule.Date = dto.Date;
            schedule.Room = dto.Room;
            schedule.Status = dto.Status;
            schedule.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ScheduleDTO(
                schedule.ScheduleID,
                schedule.ClassID,
                schedule.TeacherID,
                schedule.StudySessionId,
                schedule.Room,
                schedule.Status,
                schedule.Notes,
                schedule.CreatedAt,
                schedule.ModifiedAt,
                schedule.Date
            );
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateScheduleStatusAsync(int id, byte status, string? notes = null)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            schedule.Status = status;
            if (notes != null)
                schedule.Notes = notes;
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
                    Date = s.Date,
                    Notes = s.Notes
                })
                .ToListAsync();

            return schedules;
        }

        public async Task<IEnumerable<TeacherClassDTO>> GetTeacherClassesAsync(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên");

            var classes = await _context.Schedules
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Where(s => s.TeacherID == teacherId)
                .Select(s => new TeacherClassDTO
                {
                    ClassID = s.Class.ClassID,
                    ClassName = s.Class.ClassName,
                    CourseID = s.Class.CourseID,
                    CourseName = s.Class.Course.CourseName,
                    MaxStudents = s.Class.MaxStudents,
                    StartDate = s.Class.StartDate,
                  
                    Status = s.Class.Status
                })
                .Distinct()
                .ToListAsync();

            return classes;
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
                    Date = s.Date,
                    Notes = s.Notes
                })
                .ToListAsync();

            return schedules;
        }

        //public async Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndRangeAsync(int studentId, DateTime? from, DateTime? to)
        //{
        //    var student = await _context.Students.FindAsync(studentId);
        //    if (student == null)
        //        throw new Exception("Không tìm thấy học sinh");

        //    var classIds = await _context.StudentClassEnrollments
        //        .Where(e => e.StudentID == studentId && e.Status == 1)
        //        .Select(e => e.ClassID)
        //        .ToListAsync();

        //    var query = _context.Schedules
        //        .Where(s => classIds.Contains(s.ClassID));

        //    if (from.HasValue)
        //        query = query.Where(s => s.Date >= from.Value);
        //    if (to.HasValue)
        //        query = query.Where(s => s.Date <= to.Value);

        //    var schedules = await query
        //        .Include(s => s.StudySession)
        //        .Include(s => s.Class)
        //            .ThenInclude(c => c.Course)
        //        .Include(s => s.Teacher)
        //            .ThenInclude(t => t.User)
        //        .OrderBy(s => s.Date)
        //        .ThenBy(s => s.StudySession.StartTime)
        //        .Select(s => new StudentScheduleViewDTO
        //        {
        //            ClassID = s.ClassID,
        //            ClassName = s.Class.ClassName,
        //            CourseID = s.Class.CourseID,
        //            CourseName = s.Class.Course.CourseName,
        //            StudySessionId = s.StudySessionId,
        //            StudySessionName = s.StudySession.DisplayName,
        //            StartTime = s.StudySession.StartTime,
        //            EndTime = s.StudySession.EndTime,
        //            TeacherName = s.Teacher.User.FullName,
        //            Room = s.Room,
        //            Date = s.Date
        //        })
        //        .ToListAsync();

        //    return schedules;
        //}

        //public async Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndStatusAsync(int studentId, byte status)
        //{
        //    var student = await _context.Students.FindAsync(studentId);
        //    if (student == null)
        //        throw new Exception("Không tìm thấy học sinh");

        //    var classIds = await _context.StudentClassEnrollments
        //        .Where(e => e.StudentID == studentId && e.Status == 1)
        //        .Select(e => e.ClassID)
        //        .ToListAsync();

        //    var schedules = await _context.Schedules
        //        .Where(s => classIds.Contains(s.ClassID) && s.Status == status)
        //        .Include(s => s.StudySession)
        //        .Include(s => s.Class)
        //            .ThenInclude(c => c.Course)
        //        .Include(s => s.Teacher)
        //            .ThenInclude(t => t.User)
        //        .OrderBy(s => s.Date)
        //        .ThenBy(s => s.StudySession.StartTime)
        //        .Select(s => new StudentScheduleViewDTO
        //        {
        //            ClassID = s.ClassID,
        //            ClassName = s.Class.ClassName,
        //            CourseID = s.Class.CourseID,
        //            CourseName = s.Class.Course.CourseName,
        //            StudySessionId = s.StudySessionId,
        //            StudySessionName = s.StudySession.DisplayName,
        //            StartTime = s.StudySession.StartTime,
        //            EndTime = s.StudySession.EndTime,
        //            TeacherName = s.Teacher.User.FullName,
        //            Room = s.Room,
        //            Date = s.Date
        //        })
        //        .ToListAsync();

        //    return schedules;
        //}

        // Hàm chuyển DayOfWeek sang tiếng Việt
        string GetVietnameseDayOfWeek(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "Thứ Hai",
                DayOfWeek.Tuesday => "Thứ Ba",
                DayOfWeek.Wednesday => "Thứ Tư",
                DayOfWeek.Thursday => "Thứ Năm",
                DayOfWeek.Friday => "Thứ Sáu",
                DayOfWeek.Saturday => "Thứ Bảy",
                DayOfWeek.Sunday => "CN",
                _ => ""
            };
        }

        public async Task AutoGenerateSchedulesAsync(AutoGenerateScheduleDTO dto)
        {
            var classEntity = await _context.Classes.Include(c => c.Course).FirstOrDefaultAsync(c => c.ClassID == dto.ClassID);
            if (classEntity == null)
                throw new Exception("Không tìm thấy lớp học");
            if (classEntity.Course == null)
                throw new Exception("Lớp học chưa được gán khóa học!");

            var validRooms = new[] { "Room 01", "Room 02", "Room 03" };
            if (!validRooms.Contains(dto.Room))
                throw new Exception("Phòng học không hợp lệ. Chỉ được sử dụng Room 01, Room 02 hoặc Room 03");

            // Lấy danh sách StudySessionId hợp lệ
            var validSessionIds = await _context.StudySessions.Select(s => s.StudySessionId).ToListAsync();

            // Đếm số lịch học trạng thái khác 3 (không bị hủy)
            int slotCount = classEntity.Course.Duration;
            int currentSchedules = await _context.Schedules.CountAsync(s => s.ClassID == dto.ClassID && s.Status != 3);
            if (currentSchedules >= slotCount)
                throw new Exception($"Lớp đã có đủ {slotCount} buổi học, không thể tạo thêm!");
            int needToCreate = slotCount - currentSchedules;
            if (needToCreate <= 0) return;

            // Tìm ngày lớn nhất của lịch đã có (slot cuối cùng)
            var lastSchedule = await _context.Schedules
                .Where(s => s.ClassID == dto.ClassID)
                .OrderByDescending(s => s.Date)
                .FirstOrDefaultAsync();
            var currentDate = lastSchedule != null ? lastSchedule.Date.AddDays(1) : classEntity.StartDate.Date;

            var schedules = new List<Schedule>();
            int created = 0;
            while (created < needToCreate)
            {
                if (dto.DaysOfWeekSessions.TryGetValue(currentDate.DayOfWeek, out var sessionId))
                {
                    if (sessionId == 0) { currentDate = currentDate.AddDays(1); continue; } // Bỏ qua slot không xếp lịch
                    if (!validSessionIds.Contains(sessionId))
                        throw new Exception($"StudySessionId {sessionId} không tồn tại trong hệ thống!");
                    // Kiểm tra trùng phòng: không cho phép 2 lớp khác nhau cùng 1 ca, cùng 1 phòng, cùng 1 ngày
                    var roomConflictSchedule = await _context.Schedules
                        .Include(s => s.Class)
                        .FirstOrDefaultAsync(s =>
                            s.Date == currentDate &&
                            s.StudySessionId == sessionId &&
                            s.Room == dto.Room &&
                            s.Status != 3);
                    if (roomConflictSchedule != null)
                    {
                        string thuVN = GetVietnameseDayOfWeek(currentDate.DayOfWeek);
                        string msg = $"Trùng phòng: {dto.Room}, ({thuVN}), ca {sessionId}, đã có lớp {roomConflictSchedule.Class?.ClassName ?? roomConflictSchedule.ClassID.ToString()}!";
                        throw new Exception(msg);
                    }
                    // Kiểm tra trùng lịch lớp
                    bool classConflict = await _context.Schedules.AnyAsync(s =>
                        s.ClassID == dto.ClassID &&
                        s.Date == currentDate &&
                        s.StudySessionId == sessionId &&
                        s.Status != 3);
                    if (classConflict)
                    { currentDate = currentDate.AddDays(1); continue; }
                    schedules.Add(new Schedule
                    {
                        ClassID = dto.ClassID,
                        TeacherID = null, // Để trống giáo viên
                        StudySessionId = sessionId,
                        Date = currentDate,
                        Room = dto.Room,
                        Status = 1, // Active
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    });
                    created++;
                }
                currentDate = currentDate.AddDays(1);
            }
            _context.Schedules.AddRange(schedules);
            await _context.SaveChangesAsync();
        }

        public async Task AssignTeacherToClassAsync(int classId, int teacherId)
        {
            var allSchedules = await _context.Schedules.Where(s => s.ClassID == classId && s.Status != 3).ToListAsync();
            if (!allSchedules.Any())
                throw new Exception("Lớp học chưa được tạo lịch học!");
            var schedules = allSchedules.Where(s => s.TeacherID == null).ToList();
            if (!schedules.Any())
                throw new Exception("Không có lịch học nào chưa có giáo viên để gán!");
            foreach (var schedule in schedules)
            {
                // Kiểm tra trùng lịch giáo viên
                bool conflict = await _context.Schedules.AnyAsync(s =>
                    s.TeacherID == teacherId &&
                    s.Date == schedule.Date &&
                    s.StudySessionId == schedule.StudySessionId &&
                    s.ScheduleID != schedule.ScheduleID);
                if (conflict)
                    throw new Exception($"Giáo viên đã có lịch dạy vào ngày {schedule.Date:yyyy-MM-dd}, ca {schedule.StudySessionId}!");
                schedule.TeacherID = teacherId;
                schedule.ModifiedAt = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }

        public async Task AssignTeacherToScheduleAsync(int scheduleId, int teacherId,string notes)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
                throw new Exception("Không tìm thấy lịch học!");
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null)
                throw new Exception("Không tìm thấy giáo viên!");
            // Kiểm tra trùng lịch giáo viên
            bool conflict = await _context.Schedules.AnyAsync(s =>
                s.TeacherID == teacherId &&
                s.Date == schedule.Date &&
                s.StudySessionId == schedule.StudySessionId &&
                s.ScheduleID != schedule.ScheduleID);
            if (conflict)
                throw new Exception($"Giáo viên đã có lịch dạy vào ngày {schedule.Date:yyyy-MM-dd}, ca {schedule.StudySessionId}!");
            schedule.TeacherID = teacherId;
            schedule.Notes = notes;
            schedule.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
} 