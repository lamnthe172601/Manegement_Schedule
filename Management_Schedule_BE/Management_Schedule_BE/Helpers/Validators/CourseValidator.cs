using FluentValidation;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class CreateCourseDTOValidator : AbstractValidator<CreateCourseDTO>
    {
        public CreateCourseDTOValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Tên khóa học không được để trống")
                .MaximumLength(255).WithMessage("Tên khóa học không được vượt quá 255 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Giá khóa học phải lớn hơn hoặc bằng 0");

            RuleFor(x => x.ThumbnailUrl)
                .MaximumLength(512).WithMessage("URL hình ảnh không được vượt quá 512 ký tự");

            RuleFor(x => x.DiscountPercent)
                .InclusiveBetween((byte)0, (byte)100).WithMessage("Phần trăm giảm giá phải từ 0 đến 100");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Thời lượng khóa học phải lớn hơn 0");

            RuleFor(x => x.Level)
                .InclusiveBetween((byte)1, (byte)5).WithMessage("Cấp độ phải từ 1 đến 5");
        }
    }

    public class UpdateCourseDTOValidator : AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseDTOValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Tên khóa học không được để trống")
                .MaximumLength(255).WithMessage("Tên khóa học không được vượt quá 255 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Giá khóa học phải lớn hơn hoặc bằng 0");

            RuleFor(x => x.ThumbnailUrl)
                .MaximumLength(512).WithMessage("URL hình ảnh không được vượt quá 512 ký tự");

            RuleFor(x => x.DiscountPercent)
                .InclusiveBetween((byte)0, (byte)100).WithMessage("Phần trăm giảm giá phải từ 0 đến 100");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Thời lượng khóa học phải lớn hơn 0");

            RuleFor(x => x.Level)
                .InclusiveBetween((byte)1, (byte)5).WithMessage("Cấp độ phải từ 1 đến 5");
        }
    }
}