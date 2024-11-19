

using FluentValidation;
using Readio.Model.Comment.Dtos.Create.Request;

namespace Readio.Service.Comment.Validator;

public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(x => x.Content)
               .NotEmpty().WithMessage("Yorum içeriği boş olamaz.");
        
        RuleFor(x => x.BookId)
            .NotEqual(Guid.Empty).WithMessage("Kitap ID'si boş olamaz.");

       
        RuleFor(x => x.MemberId)
            .GreaterThan(0).WithMessage("Üye ID'si 0'dan büyük bir sayı olmalıdır.");
    }
}
