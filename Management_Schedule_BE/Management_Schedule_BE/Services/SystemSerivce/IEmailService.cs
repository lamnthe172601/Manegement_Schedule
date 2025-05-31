namespace Management_Schedule_BE.Services.SystemSerivce
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(string toEmail, string otp);
    }
}
