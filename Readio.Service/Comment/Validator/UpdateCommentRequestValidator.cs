
using FluentValidation;
using Readio.Model.Comment.Dtos.Update;

namespace Readio.Service.Comment.Validator;

public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequest>
{
    public UpdateCommentRequestValidator()
    {
        RuleFor(x => x.Id)
             .GreaterThan(0).WithMessage("Yorum ID'si pozitif bir tamsayı olmalıdır.");


        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Yorum içeriği boş olamaz.");
    }
}

