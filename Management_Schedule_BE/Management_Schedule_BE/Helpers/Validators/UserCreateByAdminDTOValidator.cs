using FluentValidation;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class UserCreateByAdminDTOValidator : AbstractValidator<UserCreateByAdminDTO>
    {
        public UserCreateByAdminDTOValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Họ tên không được để trống")
                .MaximumLength(100).WithMessage("Họ tên không được vượt quá 100 ký tự");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự");

            RuleFor(x => x.Role)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Role phải từ 1 đến 3");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Giới tính không được để trống")
                .Must(g => g == "M" || g == "F" || g == "O").WithMessage("Giới tính phải là 'M' (Nam), 'F' (Nữ), 'O' (Khác)");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Số điện thoại không được vượt quá 20 ký tự");
        }
    }
} 