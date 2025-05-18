using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class CourseValidation : AbstractValidator<Course>
    {
        public CourseValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên khóa học không được để trống")
                .Length(3, 100).WithMessage("Tên khóa học phải từ 3 đến 100 ký tự");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Mô tả không được để trống")
                .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Thời lượng không được để trống")
                .GreaterThan(0).WithMessage("Thời lượng phải lớn hơn 0");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Giá không được để trống")
                .GreaterThanOrEqualTo(0).WithMessage("Giá không được âm");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Trình độ không được để trống")
                .IsInEnum().WithMessage("Trình độ không hợp lệ");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 