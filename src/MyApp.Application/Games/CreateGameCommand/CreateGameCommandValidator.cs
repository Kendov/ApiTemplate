
using FluentValidation;

namespace MyApp.Application.Games.CreateGameCommand
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();

            RuleFor(x => x.Genre)
                .NotEmpty();
        }

    }
}