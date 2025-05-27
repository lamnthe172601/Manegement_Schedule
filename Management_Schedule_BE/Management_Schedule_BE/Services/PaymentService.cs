using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Management_Schedule_BE.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEnrollmentService _enrollmentService;

        public PaymentService(
            ApplicationDbContext context,
            IConfiguration configuration,
            IEnrollmentService enrollmentService)
        {
            _context = context;
            _configuration = configuration;
            _enrollmentService = enrollmentService;
        }

        public async Task<string> CreateVNPayPaymentAsync(CreateVNPayPaymentDTO paymentDto)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(paymentDto.EnrollmentID);
            if (enrollment == null)
                throw new Exception("Không tìm thấy thông tin đăng ký");

            var vnpayConfig = _configuration.GetSection("VNPay");
            var vnp_Url = vnpayConfig["Url"];
            var vnp_Returnurl = vnpayConfig["ReturnUrl"];
            var vnp_TmnCode = vnpayConfig["TmnCode"];
            var vnp_HashSecret = vnpayConfig["HashSecret"];

            var vnp_TxnRef = DateTime.Now.Ticks.ToString();
            var vnp_OrderInfo = paymentDto.OrderInfo;
            var vnp_OrderType = "other";
            var vnp_Amount = (paymentDto.Amount * 100).ToString();
            var vnp_Locale = "vn";
            var vnp_IpAddr = "127.0.0.1";
            var vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");

            var inputData = new SortedList<string, string>
            {
                { "vnp_Version", "2.1.0" },
                { "vnp_Command", "pay" },
                { "vnp_TmnCode", vnp_TmnCode },
                { "vnp_Amount", vnp_Amount },
                { "vnp_CreateDate", vnp_CreateDate },
                { "vnp_CurrCode", "VND" },
                { "vnp_IpAddr", vnp_IpAddr },
                { "vnp_Locale", vnp_Locale },
                { "vnp_OrderInfo", vnp_OrderInfo },
                { "vnp_OrderType", vnp_OrderType },
                { "vnp_ReturnUrl", vnp_Returnurl },
                { "vnp_TxnRef", vnp_TxnRef }
            };

            var queryString = string.Join("&", inputData.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var signData = string.Join("&", inputData.Select(kv => $"{kv.Key}={kv.Value}"));
            var vnp_SecureHash = HmacSHA512(vnp_HashSecret, signData);

            return $"{vnp_Url}?{queryString}&vnp_SecureHash={vnp_SecureHash}";
        }

        public async Task<VNPayReturnDTO> HandleVNPayReturnAsync(Dictionary<string, string> vnpayData)
        {
            var vnpayConfig = _configuration.GetSection("VNPay");
            var vnp_HashSecret = vnpayConfig["HashSecret"];

            var vnp_SecureHash = vnpayData["vnp_SecureHash"];
            vnpayData.Remove("vnp_SecureHash");
            vnpayData.Remove("vnp_SecureHashType");

            var signData = string.Join("&", vnpayData.Select(kv => $"{kv.Key}={kv.Value}"));
            var checkSignature = HmacSHA512(vnp_HashSecret, signData);

            if (checkSignature != vnp_SecureHash)
                return new VNPayReturnDTO("97", "Invalid signature");

            var vnp_ResponseCode = vnpayData["vnp_ResponseCode"];
            var vnp_TxnRef = vnpayData["vnp_TxnRef"];
            var vnp_Amount = decimal.Parse(vnpayData["vnp_Amount"]) / 100;
            var vnp_OrderInfo = vnpayData["vnp_OrderInfo"];

            if (vnp_ResponseCode == "00")
            {
                // Tạo bản ghi thanh toán
                var payment = new StudentTuitionHistory
                {
                    EnrollmentID = int.Parse(vnp_OrderInfo.Split('_')[1]),
                    AmountPaid = vnp_Amount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = 3, // Credit Card
                    TransactionID = vnp_TxnRef,
                    Status = 2 // Completed
                };

                _context.StudentTuitionHistories.Add(payment);

                // Cập nhật trạng thái đăng ký
                var enrollment = await _context.StudentClassEnrollments.FindAsync(payment.EnrollmentID);
                if (enrollment != null)
                {
                    enrollment.TuitionPaid += vnp_Amount;
                    if (enrollment.TuitionPaid >= enrollment.TotalTuitionDue)
                    {
                        enrollment.Status = 1; // Active
                    }
                }

                await _context.SaveChangesAsync();
                return new VNPayReturnDTO("00", "Confirm Success");
            }

            return new VNPayReturnDTO(vnp_ResponseCode, "Payment failed");
        }

        public async Task<IEnumerable<PaymentHistoryDTO>> GetStudentPaymentHistoryAsync(int studentId)
        {
            var payments = await _context.StudentTuitionHistories
                .Include(p => p.Enrollment)
                .ThenInclude(e => e.Class)
                .ThenInclude(c => c.Course)
                .Where(p => p.Enrollment.StudentID == studentId)
                .Select(p => new PaymentHistoryDTO(
                    p.PaymentID,
                    p.EnrollmentID,
                    p.Enrollment.Class.ClassName,
                    p.Enrollment.Class.Course.CourseName,
                    p.AmountPaid,
                    p.PaymentDate,
                    p.PaymentMethod,
                    p.TransactionID,
                    p.Status
                ))
                .ToListAsync();

            return payments;
        }

        public async Task<PaymentDTO?> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _context.StudentTuitionHistories.FindAsync(paymentId);
            if (payment == null)
                return null;

            return new PaymentDTO(
                payment.PaymentID,
                payment.EnrollmentID,
                payment.TuitionID,
                payment.AmountPaid,
                payment.PaymentDate,
                payment.PaymentMethod,
                payment.TransactionID,
                payment.Status,
                payment.CreatedAt,
                payment.ModifiedAt
            );
        }

        private string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }
            return hash.ToString();
        }
    }
} 