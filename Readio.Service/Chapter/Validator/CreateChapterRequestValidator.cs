

using FluentValidation;
using Readio.Model.Chapter.Dtos.Create.Request;

namespace Readio.Service.Chapter.Validator;

public class CreateChapterRequestValidator : AbstractValidator<CreateChapterRequest>
{
    public CreateChapterRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Bölüm başlığı boş olamaz.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Bölüm içeriği boş olamaz.");

        RuleFor(x => x.BookId)
           .NotEqual(Guid.Empty).WithMessage("Kitap ID'si boş olamaz.");
    }
}
