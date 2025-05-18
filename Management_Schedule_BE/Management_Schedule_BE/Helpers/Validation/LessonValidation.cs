using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class LessonValidation : AbstractValidator<Lesson>
    {
        public LessonValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Tiêu đề không được để trống")
                .Length(3, 200).WithMessage("Tiêu đề phải từ 3 đến 200 ký tự");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Mô tả không được để trống")
                .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Khóa học không được để trống");

            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Thứ tự bài học không được để trống")
                .GreaterThan(0).WithMessage("Thứ tự bài học phải lớn hơn 0");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Thời lượng không được để trống")
                .GreaterThan(0).WithMessage("Thời lượng phải lớn hơn 0");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 