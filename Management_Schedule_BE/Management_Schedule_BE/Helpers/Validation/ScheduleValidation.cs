using FluentValidation;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Validation
{
    public class ScheduleValidation : AbstractValidator<Schedule>
    {
        public ScheduleValidation()
        {
            RuleFor(x => x.ClassId)
                .NotEmpty().WithMessage("Lớp học không được để trống");

            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("Giáo viên không được để trống");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Thời gian bắt đầu không được để trống")
                .LessThan(x => x.EndTime).WithMessage("Thời gian bắt đầu phải trước thời gian kết thúc");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Thời gian kết thúc không được để trống")
                .GreaterThan(x => x.StartTime).WithMessage("Thời gian kết thúc phải sau thời gian bắt đầu");

            RuleFor(x => x.Room)
                .NotEmpty().WithMessage("Phòng học không được để trống")
                .MaximumLength(50).WithMessage("Tên phòng học không được vượt quá 50 ký tự");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Trạng thái không được để trống")
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
} 