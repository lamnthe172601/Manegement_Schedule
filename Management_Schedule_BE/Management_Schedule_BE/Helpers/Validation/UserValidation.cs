using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Tên đăng nhập không được để trống")
                .Length(3, 50).WithMessage("Tên đăng nhập phải từ 3 đến 50 ký tự");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Họ tên không được để trống")
                .Length(2, 100).WithMessage("Họ tên phải từ 2 đến 100 ký tự");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Số điện thoại không được để trống")
                .Matches(@"^[0-9]{10}$").WithMessage("Số điện thoại không hợp lệ");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Vai trò không được để trống")
                .IsInEnum().WithMessage("Vai trò không hợp lệ");
        }
    }
} 