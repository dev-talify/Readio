
using FluentValidation;
using Readio.Model.Member.Dtos.Update;

namespace Readio.Service.Member.Validator;

public class UpdateMemberRequestValidator : AbstractValidator<UpdateMemberRequest>
{
    public UpdateMemberRequestValidator()
    {
        RuleFor(x => x.Id)
        .GreaterThan(0).WithMessage("Geçerli bir ID olmalıdır.");

        RuleFor(x => x.FirstName)
         .NotEmpty().WithMessage("Üye adı boş olamaz.")
         .Length(1, 55).WithMessage("Üye adı 1 ile 55 karakter arasnda olmalıdır.");

        RuleFor(x => x.LastName)
         .NotEmpty().WithMessage("Soyadı boş olamaz.")
         .Length(1, 55).WithMessage("Üye adı 1 ile 55 karakter arasnda olmalıdır.");
    }
}
