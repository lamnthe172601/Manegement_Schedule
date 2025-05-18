using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class SalaryValidation : AbstractValidator<Salary>
    {
        public SalaryValidation()
        {
            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("Giáo viên không được để trống");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Số tiền không được để trống")
                .GreaterThan(0).WithMessage("Số tiền phải lớn hơn 0");

            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("Ngày thanh toán không được để trống")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Ngày thanh toán không hợp lệ");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Phương thức thanh toán không được để trống")
                .IsInEnum().WithMessage("Phương thức thanh toán không hợp lệ");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");

            RuleFor(x => x.Month)
                .NotEmpty().WithMessage("Tháng không được để trống")
                .InclusiveBetween(1, 12).WithMessage("Tháng phải từ 1 đến 12");

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Năm không được để trống")
                .GreaterThan(2000).WithMessage("Năm không hợp lệ");
        }
    }
} 