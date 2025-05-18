using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class TeacherValidation : AbstractValidator<Teacher>
    {
        public TeacherValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Họ tên không được để trống")
                .Length(2, 100).WithMessage("Họ tên phải từ 2 đến 100 ký tự");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Số điện thoại không được để trống")
                .Matches(@"^[0-9]{10}$").WithMessage("Số điện thoại không hợp lệ");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Ngày sinh không được để trống")
                .LessThan(DateTime.Now).WithMessage("Ngày sinh không hợp lệ");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Giới tính không được để trống")
                .IsInEnum().WithMessage("Giới tính không hợp lệ");

            RuleFor(x => x.Specialization)
                .NotEmpty().WithMessage("Chuyên môn không được để trống")
                .MaximumLength(200).WithMessage("Chuyên môn không được vượt quá 200 ký tự");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 