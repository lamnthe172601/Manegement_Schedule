using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class ClassValidation : AbstractValidator<Class>
    {
        public ClassValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên lớp không được để trống")
                .Length(3, 100).WithMessage("Tên lớp phải từ 3 đến 100 ký tự");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Khóa học không được để trống");

            RuleFor(x => x.MaxStudents)
                .NotEmpty().WithMessage("Số học viên tối đa không được để trống")
                .GreaterThan(0).WithMessage("Số học viên tối đa phải lớn hơn 0");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 