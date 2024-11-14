

using FluentValidation;
using Readio.Model.Genre.Dtos.Update;

namespace Readio.Service.Genre.Validator;

public class UpdateGenreRequestValidator : AbstractValidator<UpdateGenreRequest>
{
    public UpdateGenreRequestValidator()
    {

        RuleFor(x => x.Id)
        .GreaterThan(0).WithMessage("Geçerli bir kategori ID'si sağlanmalıdır.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .Length(1, 100).WithMessage("Kategori adı 1 ile 50 karakter arasında olmalıdır.");

    }
}
