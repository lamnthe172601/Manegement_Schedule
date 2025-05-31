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
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetAllSchedules()
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
        public async Task<ActionResult<ScheduleDTO>> CreateSchedule(CreateScheduleDTO dto)
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
    }
} 