using FluentValidation;

namespace MyApp.Application.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(5000);
        }
    }
}