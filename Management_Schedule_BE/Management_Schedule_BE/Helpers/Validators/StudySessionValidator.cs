using FluentValidation;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class CreateStudySessionDTOValidator : AbstractValidator<CreateStudySessionDTO>
    {
        public CreateStudySessionDTOValidator()
        {
            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Tên ca học không được để trống")
                .MaximumLength(100).WithMessage("Tên ca học không được vượt quá 100 ký tự");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Giờ bắt đầu không được để trống")
                .MaximumLength(50).WithMessage("Giờ bắt đầu không được vượt quá 50 ký tự");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Giờ kết thúc không được để trống")
                .MaximumLength(50).WithMessage("Giờ kết thúc không được vượt quá 50 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");
        }
    }

    public class UpdateStudySessionDTOValidator : AbstractValidator<UpdateStudySessionDTO>
    {
        public UpdateStudySessionDTOValidator()
        {
            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Tên ca học không được để trống")
                .MaximumLength(100).WithMessage("Tên ca học không được vượt quá 100 ký tự");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Giờ bắt đầu không được để trống")
                .MaximumLength(50).WithMessage("Giờ bắt đầu không được vượt quá 50 ký tự");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Giờ kết thúc không được để trống")
                .MaximumLength(50).WithMessage("Giờ kết thúc không được vượt quá 50 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");
        }
    }
}