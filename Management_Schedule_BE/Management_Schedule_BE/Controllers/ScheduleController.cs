using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ODataController
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<DetailedScheduleDTO>>> GetAllSchedules()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<ScheduleDTO>> GetScheduleById(int id)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByIdAsync(id);
                if (schedule == null)
                    return NotFound(new { message = "Không tìm thấy lịch" });
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSchedule(CreateScheduleDTO dto)
        {
            try
            {
                var schedule = await _scheduleService.CreateScheduleAsync(dto);
                return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.ScheduleID }, schedule);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Mã ca học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleDTO>> UpdateSchedule(int id, UpdateScheduleDTO dto)
        {
            try
            {
                var schedule = await _scheduleService.UpdateScheduleAsync(id, dto);
                if (schedule == null)
                    return NotFound(new { message = "Không tìm thấy lịch" });
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Mã ca học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchedule(int id)
        {
            try
            {
                var result = await _scheduleService.DeleteScheduleAsync(id);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy lịch" });
                return Ok(new { message = "Xóa lịch thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateScheduleStatus(int id, [FromBody] UpdateScheduleStatusDTO dto)
        {
            try
            {
                var result = await _scheduleService.UpdateScheduleStatusAsync(id, dto.Status);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy lịch" });
                return Ok(new { message = "Cập nhật trạng thái lịch thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("teacher/{teacherId}")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TeacherScheduleViewDTO>>> GetSchedulesByTeacherId(int teacherId)
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByTeacherIdAsync(teacherId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Không tìm thấy giáo viên"))
                    return NotFound(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        //[HttpGet("teacher/{teacherId}/range")]
        //[EnableQuery]
        //public async Task<ActionResult<IEnumerable<TeacherScheduleViewDTO>>> GetSchedulesByTeacherIdAndRange(
        //    int teacherId,
        //    [FromQuery] DateTime? from,
        //    [FromQuery] DateTime? to)
        //{
        //    try
        //    {
        //        var schedules = await _scheduleService.GetSchedulesByTeacherIdAndRangeAsync(teacherId, from, to);
        //        return Ok(schedules);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Không tìm thấy giáo viên"))
        //            return NotFound(new { message = ex.Message });
        //        return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
        //    }
        //}

        //[HttpGet("teacher/{teacherId}/statusSchedule/{status}")]
        //[EnableQuery]
        //public async Task<ActionResult<IEnumerable<TeacherScheduleViewDTO>>> GetSchedulesByTeacherIdAndStatus(
        //    int teacherId, byte status)
        //{
        //    try
        //    {
        //        var schedules = await _scheduleService.GetSchedulesByTeacherIdAndStatusAsync(teacherId, status);
        //        return Ok(schedules);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Không tìm thấy giáo viên"))
        //            return NotFound(new { message = ex.Message });
        //        return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
        //    }
        //}

        [HttpGet("date/{date}")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TeacherScheduleViewDTO>>> GetSchedulesByDate(DateTime date)
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByDateAsync(date);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("student/{studentId}")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StudentScheduleViewDTO>>> GetSchedulesByStudentId(int studentId)
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByStudentIdAsync(studentId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Không tìm thấy học sinh"))
                    return NotFound(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        //[HttpGet("student/{studentId}/range")]
        //[EnableQuery]
        //public async Task<ActionResult<IEnumerable<StudentScheduleViewDTO>>> GetSchedulesByStudentIdAndRange(
        //    int studentId,
        //    [FromQuery] DateTime? from,
        //    [FromQuery] DateTime? to)
        //{
        //    try
        //    {
        //        var schedules = await _scheduleService.GetSchedulesByStudentIdAndRangeAsync(studentId, from, to);
        //        return Ok(schedules);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Không tìm thấy học sinh"))
        //            return NotFound(new { message = ex.Message });
        //        return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
        //    }
        //}

        //[HttpGet("student/{studentId}/statusSchedule/{status}")]
        //[EnableQuery]
        //public async Task<ActionResult<IEnumerable<TeacherScheduleViewDTO>>> GetSchedulesByStudentIdAndStatus(
        //    int studentId, byte status)
        //{
        //    try
        //    {
        //        var schedules = await _scheduleService.GetSchedulesByStudentIdAndStatusAsync(studentId, status);
        //        return Ok(schedules);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Không tìm thấy học sinh"))
        //            return NotFound(new { message = ex.Message });
        //        return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
        //    }
        //}

        [HttpPost("auto-generate")]
        public async Task<ActionResult> AutoGenerateSchedules([FromBody] AutoGenerateScheduleDTO dto)
        {
            try
            {
                await _scheduleService.AutoGenerateSchedulesAsync(dto);
                return Ok(new { message = "Tạo lịch học tự động thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("assign-teacher-to-class")]
        public async Task<ActionResult> AssignTeacherToClass([FromBody] AssignTeacherToClassDTO dto)
        {
            try
            {
                await _scheduleService.AssignTeacherToClassAsync(dto.ClassID, dto.TeacherID);
                return Ok(new { message = "Gán giáo viên cho toàn bộ lịch của lớp thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("assign-teacher")]
        public async Task<ActionResult> AssignTeacherToSchedule([FromBody] AssignTeacherToScheduleDTO dto)
        {
            try
            {
                await _scheduleService.AssignTeacherToScheduleAsync(dto.ScheduleID, dto.TeacherID,dto.notes);
                return Ok(new { message = "Gán giáo viên cho lịch thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 