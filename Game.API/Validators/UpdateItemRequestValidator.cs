using FluentValidation;
using Game.API.Contracts.Item;
using Game.API.Models.Enums;

using Type = Game.API.Models.Enums.Type;

namespace Game.API.Validators;

public class UpdateItemRequestValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemRequestValidator()
    {
        RuleFor(i => i.Name)
            .Length(1, 12)
            .WithMessage("'{PropertyName}' must not be empty and limited to 12 characters.");

        RuleFor(i => i.Description)
            .Length(1, 60)
            .WithMessage("'{PropertyName}' must not be empty and limited to 60 characters.");

        RuleFor(i => i.Type)
            .Must(t => Enum.IsDefined(typeof(Type), t))
            .WithMessage("'{PropertyName}' value is invalid. You provided '{PropertyValue}'.");

        RuleFor(i => i.Element)
            .Must(e => Enum.IsDefined(typeof(Element), e))
            .WithMessage("'{PropertyName}' value is invalid. You provided '{PropertyValue}'.");
            
        RuleFor(i => i.Price)
            .GreaterThan(0)
            .WithMessage("'{PropertyName}' value must be greater than '0'. You provided '{PropertyValue}'.");
    }
}
