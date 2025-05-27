using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ApplicationDbContext _context;

        public PaymentController(
            IPaymentService paymentService,
            ApplicationDbContext context)
        {
            _paymentService = paymentService;
            _context = context;
        }

        [HttpPost("vnpay/create")]
        [Authorize]
        public async Task<ActionResult<string>> CreateVNPayPayment([FromBody] CreateVNPayPaymentDTO paymentDto)
        {
            try
            {
                var paymentUrl = await _paymentService.CreateVNPayPaymentAsync(paymentDto);
                return Ok(new { paymentUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("vnpay/return")]
        public async Task<ActionResult<VNPayReturnDTO>> HandleVNPayReturn()
        {
            try
            {
                var vnpayData = Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());
                var result = await _paymentService.HandleVNPayReturnAsync(vnpayData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("history/me")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PaymentHistoryDTO>>> GetMyPaymentHistory()
        {
            try
            {
                // Lấy Email từ token (ưu tiên claim 'email', fallback sang User.Identity.Name)
                var email = User.FindFirst("email")?.Value ?? User.Identity?.Name;
                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { message = "Không tìm thấy thông tin người dùng" });

                // Tìm StudentID từ Email
                var student = await _context.Students
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.User.Email == email);

                if (student == null)
                    return Unauthorized(new { message = "Không tìm thấy thông tin học sinh" });

                var payments = await _paymentService.GetStudentPaymentHistoryAsync(student.StudentID);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PaymentDTO>> GetPaymentById(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);
                if (payment == null)
                    return NotFound(new { message = "Không tìm thấy thông tin thanh toán" });

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 