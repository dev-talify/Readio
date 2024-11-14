
using FluentValidation;
using Readio.Model.Author.Dtos.Create.Request;

namespace Readio.Service.Genre.Validator;

public class CreateGenreRequestValidator : AbstractValidator<CreateAuthorRequest>
{
    public CreateGenreRequestValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .Length(1, 100).WithMessage("Kategori adı 1 ile 50 karakter arasında olmalıdır.");

    }
}
