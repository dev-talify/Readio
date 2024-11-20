
using FluentValidation;
using Readio.Model.Chapter.Dtos.Update;

namespace Readio.Service.Chapter.Validator;

public class UpdateChapterRequestValidator : AbstractValidator<UpdateChapterRequest>
{
    public UpdateChapterRequestValidator()
    {
        RuleFor(x => x.Id)
             .GreaterThan(0).WithMessage("Bölüm ID'si pozitif bir tamsayı olmalıdır.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Bölüm başlığı boş olamaz.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Bölüm içeriği boş olamaz.");
    }
    
}
