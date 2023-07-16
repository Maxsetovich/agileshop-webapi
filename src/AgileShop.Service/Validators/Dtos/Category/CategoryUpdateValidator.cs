using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Categories;
using FluentValidation;

namespace AgileShop.Service.Validators.Dtos.Category;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is reuired")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSize = 5;
            RuleFor(dto => dto.Image.Length).LessThan(maxImageSize * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSize} MB");
            RuleFor(dto => dto.Image.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
