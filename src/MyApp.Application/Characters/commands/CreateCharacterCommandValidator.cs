using FluentValidation;
using MyApp.Application.Characters.Commands;

namespace MyApp.Application.Characters.commands
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Class)
                .IsInEnum();

            RuleFor(x => x.Items)
                .NotEmpty();
        }
    }
}
