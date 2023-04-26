using FluentValidation;
using Game.API.Contracts.Item;
using Game.API.Models.Enums;

using Type = Game.API.Models.Enums.Type;

namespace Game.API.Validators;

public class PostItemRequestValidator : AbstractValidator<PostItemRequest>
{
    public PostItemRequestValidator()
    {
        RuleFor(i => i.Name)
            .Length(1, 12)
            .WithMessage("Name must not be empty and limited to 12 characters.");
        RuleFor(i => i.Description)
            .Length(1, 60)
            .WithMessage("Description must not be empty and limited to 60 characters.");
        RuleFor(i => i.Type)
            .Must(t => Enum.IsDefined(typeof(Type), t))
            .WithMessage("Type value is invalid.");
        RuleFor(i => i.Element)
            .Must(e => Enum.IsDefined(typeof(Element), e))
            .WithMessage("Element value is invalid.");
        RuleFor(i => i.Price)
            .GreaterThan(0)
            .WithMessage("Price can't have '0' value.");
    }
}
