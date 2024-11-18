

using FluentValidation;
using Readio.Model.Member.Dtos.Create.Request;

namespace Readio.Service.Member.Validator;

public class CreateMemberRequestValidator : AbstractValidator<CreateMemberRequest>
{
    public CreateMemberRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Üye adı boş olamaz.")
            .Length(1, 50).WithMessage("Üye adı 1 ile 50 karakter arasında olmalıdır.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Üye soyadı boş olamaz.")
            .Length(1, 50).WithMessage("Üye soyadı 1 ile 50 karakter arasında olmalıdır.");

        RuleFor(x => x.ProfilePicture)
            .Length(1, 255).WithMessage("Üye adı 1 ile 255 karakter arasında olmalıdır.");
    }
}
