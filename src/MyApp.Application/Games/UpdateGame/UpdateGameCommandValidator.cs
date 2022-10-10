using FluentValidation;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.UpdateGame
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(Game.DESCRIPTION_MAX_LENGTH);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(Game.NAME_MAX_LENGTH);

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .MaximumLength(Game.PUBLISHER_MAX_LENGTH);

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();

            RuleFor(x => x.Genre)
                .IsInEnum();
        }

    }
}