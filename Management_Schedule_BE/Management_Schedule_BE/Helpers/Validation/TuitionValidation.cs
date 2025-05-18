using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class TuitionValidation : AbstractValidator<Tuition>
    {
        public TuitionValidation()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Học viên không được để trống");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Khóa học không được để trống");

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
        }
    }
} 