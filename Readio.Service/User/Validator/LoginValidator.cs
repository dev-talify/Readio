

using FluentValidation;
using Readio.Model.User.Dtos.Login;

namespace Readio.Service.User.Validator;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
               .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
               .EmailAddress().WithMessage("Geçersiz e-posta adresi.");

        // Şifre doğrulama
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.");
    }
}
