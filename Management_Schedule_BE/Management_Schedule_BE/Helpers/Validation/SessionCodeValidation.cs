using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class SessionCodeValidation : AbstractValidator<SessionCode>
    {
        public SessionCodeValidation()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Mã phiên không được để trống")
                .Length(6, 10).WithMessage("Mã phiên phải từ 6 đến 10 ký tự");

            RuleFor(x => x.ScheduleId)
                .NotEmpty().WithMessage("Lịch học không được để trống");

            RuleFor(x => x.ExpiryTime)
                .NotEmpty().WithMessage("Thời gian hết hạn không được để trống")
                .GreaterThan(DateTime.Now).WithMessage("Thời gian hết hạn phải lớn hơn thời gian hiện tại");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 