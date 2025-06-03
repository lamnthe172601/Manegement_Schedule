using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IPaymentService
    {
        Task<string> CreateVNPayPaymentAsync(CreateVNPayPaymentDTO paymentDto);
        Task<VNPayReturnDTO> ProcessVNPayReturnAsync(Dictionary<string, string> vnpayData);
        Task<IEnumerable<PaymentHistoryDTO>> GetStudentPaymentHistoryAsync(int studentId);
        Task<PaymentDTO?> GetPaymentByIdAsync(int paymentId);
    }
} 