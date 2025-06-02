using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<ActionResult<TeacherScheduleReportDTO>> GetTeacherScheduleReport(
            int teacherId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var report = await _reportService.GetTeacherScheduleReportAsync(teacherId, startDate, endDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("class/{classId}")]
        public async Task<ActionResult<ClassScheduleReportDTO>> GetClassScheduleReport(
            int classId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var report = await _reportService.GetClassScheduleReportAsync(classId, startDate, endDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("room/{room}")]
        public async Task<ActionResult<RoomScheduleReportDTO>> GetRoomScheduleReport(
            string room,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var report = await _reportService.GetRoomScheduleReportAsync(room, startDate, endDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("daily")]
        public async Task<ActionResult<DailyScheduleReportDTO>> GetDailyScheduleReport(
            [FromQuery] DateTime date)
        {
            try
            {
                var report = await _reportService.GetDailyScheduleReportAsync(date);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teacher/{teacherId}/statistics")]
        public async Task<ActionResult<TeacherStatisticsDTO>> GetTeacherStatistics(
            int teacherId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var statistics = await _reportService.GetTeacherStatisticsAsync(teacherId, startDate, endDate);
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("room/{room}/statistics")]
        public async Task<ActionResult<RoomStatisticsDTO>> GetRoomStatistics(
            string room,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var statistics = await _reportService.GetRoomStatisticsAsync(room, startDate, endDate);
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 