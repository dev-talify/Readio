

using FluentValidation;
using Readio.Model.Author.Dtos.Create.Request;

namespace Readio.Service.Author.Validator;

public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
{
    public CreateAuthorRequestValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Yazar adı boş olamaz.")
            .Length(2, 100).WithMessage("Yazar adı 2 ile 100 karakter arasında olmalıdır.");

        
        RuleFor(x => x.Bio)
            .MaximumLength(500).WithMessage("Biyografi 500 karakteri geçemez.");
    }
}
