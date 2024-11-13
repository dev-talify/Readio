

using FluentValidation;
using Readio.Model.Book.Dtos.Update;

namespace Readio.Service.Book.Validator;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id boş olamaz.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık alanı boş olamaz.")
            .MaximumLength(255).WithMessage("Başlık en fazla 255 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");
    }
}
