using FluentValidation;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Helpers.Validators
{
    public class CreateLessonDTOValidator : AbstractValidator<CreateLessonDTO>
    {
        public CreateLessonDTOValidator()
        {
            RuleFor(x => x.LessonName)
                .NotEmpty().WithMessage("Tên bài học không được để trống")
                .MaximumLength(255).WithMessage("Tên bài học không được vượt quá 255 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");

            RuleFor(x => x.ContentUrl)
                .NotEmpty().WithMessage("Nội dung bài học không được để trống")
                .MaximumLength(512).WithMessage("URL nội dung không được vượt quá 512 ký tự");

            RuleFor(x => x.ThumbnailUrl)
                .MaximumLength(512).WithMessage("URL hình ảnh không được vượt quá 512 ký tự");

            RuleFor(x => x.Position)
                .GreaterThan(0).WithMessage("Vị trí phải lớn hơn 0");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Thời lượng phải lớn hơn 0");

            RuleFor(x => x.Type)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Loại bài học phải từ 1 đến 3");
        }
    }

    public class UpdateLessonDTOValidator : AbstractValidator<UpdateLessonDTO>
    {
        public UpdateLessonDTOValidator()
        {
            RuleFor(x => x.LessonName)
                .NotEmpty().WithMessage("Tên bài học không được để trống")
                .MaximumLength(255).WithMessage("Tên bài học không được vượt quá 255 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");

            RuleFor(x => x.ContentUrl)
                .NotEmpty().WithMessage("Nội dung bài học không được để trống")
                .MaximumLength(512).WithMessage("URL nội dung không được vượt quá 512 ký tự");

            RuleFor(x => x.ThumbnailUrl)
                .MaximumLength(512).WithMessage("URL hình ảnh không được vượt quá 512 ký tự");

            RuleFor(x => x.Position)
                .GreaterThan(0).WithMessage("Vị trí phải lớn hơn 0");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Thời lượng phải lớn hơn 0");

            RuleFor(x => x.Type)
                .InclusiveBetween((byte)1, (byte)3).WithMessage("Loại bài học phải từ 1 đến 3");
        }
    }
}