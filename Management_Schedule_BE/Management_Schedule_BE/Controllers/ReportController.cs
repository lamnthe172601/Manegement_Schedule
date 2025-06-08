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

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardAdminDTO>> GetDashboardAdmin()
        {
            var dashboard = await _reportService.GetDashboardAdminAsync();
            return Ok(dashboard);
        }

        [HttpGet("schedule-status-statistics")]
        public async Task<ActionResult<ScheduleStatusStatisticsDTO>> GetScheduleStatusStatistics()
        {
            var data = await _reportService.GetScheduleStatusStatisticsAsync();
            return Ok(data);
        }

        [HttpGet("top-teachers")]
        public async Task<ActionResult<List<TopTeacherDTO>>> GetTopTeachers([FromQuery] int top = 5)
        {
            var data = await _reportService.GetTopTeachersAsync(top);
            return Ok(data);
        }

        [HttpGet("student-distribution-by-class")]
        public async Task<ActionResult<List<StudentDistributionByClassDTO>>> GetStudentDistributionByClass()
        {
            var data = await _reportService.GetStudentDistributionByClassAsync();
            return Ok(data);
        }
    }
} 