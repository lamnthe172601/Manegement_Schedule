using FluentValidation;
using Management_Schedule_BE.DTOs.ClassDTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class CreateClassDTOValidator : AbstractValidator<CreateClassDTO>
    {
        public CreateClassDTOValidator()
        {
            RuleFor(x => x.ClassName)
                .NotEmpty().WithMessage("Tên lớp không được để trống")
                .MaximumLength(100).WithMessage("Tên lớp không được vượt quá 100 ký tự");

            RuleFor(x => x.CourseID)
                .GreaterThan(0).WithMessage("Khóa học không hợp lệ");

            RuleFor(x => x.MaxStudents)
                .GreaterThan(0).WithMessage("Số lượng học viên tối đa phải lớn hơn 0");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Ngày bắt đầu không được để trống");

            RuleFor(x => x.Status)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Trạng thái phải từ 1 đến 3");
        }
    }

    public class UpdateClassDTOValidator : AbstractValidator<UpdateClassDTO>
    {
        public UpdateClassDTOValidator()
        {
            RuleFor(x => x.ClassName)
                .NotEmpty().WithMessage("Tên lớp không được để trống")
                .MaximumLength(100).WithMessage("Tên lớp không được vượt quá 100 ký tự");

            RuleFor(x => x.MaxStudents)
                .GreaterThan(0).WithMessage("Số lượng học viên tối đa phải lớn hơn 0");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Ngày bắt đầu không được để trống");

            RuleFor(x => x.Status)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Trạng thái phải từ 1 đến 3");
        }
    }
}