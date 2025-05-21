using FluentValidation;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class CreateScheduleDTOValidator : AbstractValidator<CreateScheduleDTO>
    {
        public CreateScheduleDTOValidator()
        {
            RuleFor(x => x.ClassID)
                .GreaterThan(0).WithMessage("Lớp học không hợp lệ");

            RuleFor(x => x.TeacherID)
                .GreaterThan(0).WithMessage("Giáo viên không hợp lệ");

            RuleFor(x => x.SessionCode)
                .NotEmpty().WithMessage("Mã ca học không được để trống")
                .MaximumLength(20).WithMessage("Mã ca học không được vượt quá 20 ký tự");

            RuleFor(x => x.DayOfWeek)
                .InclusiveBetween((byte)1, (byte)7).WithMessage("Thứ trong tuần phải từ 1 đến 7");

            RuleFor(x => x.TimeSlot)
                .NotEmpty().WithMessage("Khung giờ không được để trống")
                .MaximumLength(50).WithMessage("Khung giờ không được vượt quá 50 ký tự");

            RuleFor(x => x.Subject)
                .MaximumLength(255).WithMessage("Tên môn học không được vượt quá 255 ký tự");

            RuleFor(x => x.Room)
                .NotEmpty().WithMessage("Phòng học không được để trống")
                .MaximumLength(50).WithMessage("Phòng học không được vượt quá 50 ký tự");

            RuleFor(x => x.Status)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Trạng thái phải từ 1 đến 3");
        }
    }

    public class UpdateScheduleDTOValidator : AbstractValidator<UpdateScheduleDTO>
    {
        public UpdateScheduleDTOValidator()
        {
            RuleFor(x => x.TeacherID)
                .GreaterThan(0).WithMessage("Giáo viên không hợp lệ");

            RuleFor(x => x.SessionCode)
                .NotEmpty().WithMessage("Mã ca học không được để trống")
                .MaximumLength(20).WithMessage("Mã ca học không được vượt quá 20 ký tự");

            RuleFor(x => x.DayOfWeek)
                .InclusiveBetween((byte)1, (byte)7).WithMessage("Thứ trong tuần phải từ 1 đến 7");

            RuleFor(x => x.TimeSlot)
                .NotEmpty().WithMessage("Khung giờ không được để trống")
                .MaximumLength(50).WithMessage("Khung giờ không được vượt quá 50 ký tự");

            RuleFor(x => x.Subject)
                .MaximumLength(255).WithMessage("Tên môn học không được vượt quá 255 ký tự");

            RuleFor(x => x.Room)
                .NotEmpty().WithMessage("Phòng học không được để trống")
                .MaximumLength(50).WithMessage("Phòng học không được vượt quá 50 ký tự");

            RuleFor(x => x.Status)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Trạng thái phải từ 1 đến 3");
        }
    }
}