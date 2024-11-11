

using FluentValidation;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Entity;

namespace Readio.Service.Example.Validator;

public class CreateExampleRequestValidator : AbstractValidator<CreateExampleRequest>
{
    public CreateExampleRequestValidator()
    {
        //Fluent validation kodları
        //RuleFor(x=> x.Name)
    }
}
