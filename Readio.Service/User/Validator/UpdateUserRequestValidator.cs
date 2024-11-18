

using FluentValidation;
using Readio.Model.User.Dtos.Update;

namespace Readio.Service.User.Validator;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
               .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");
    }
}
