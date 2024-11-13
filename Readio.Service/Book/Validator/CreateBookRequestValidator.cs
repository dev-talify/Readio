

using FluentValidation;
using Readio.Model.Book.Dtos.Create.Request;

namespace Readio.Service.Book.Validator;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
           .NotEmpty().WithMessage("Başlık alanı boş olamaz.")
           .MaximumLength(255).WithMessage("Başlık en fazla 255 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş olamaz")
            .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");
    }
}
