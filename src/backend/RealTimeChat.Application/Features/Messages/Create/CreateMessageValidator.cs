using FluentValidation;

namespace RealTimeChat.Application.Features.Messages.Create;

public class CreateMessageValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageValidator()
    {
        RuleFor(message => message.Content)
            .NotEmpty()
                .WithMessage("Content cannot be empty.")
            .MaximumLength(300)
                .WithMessage("Content must not exceed 300 characters.");

        RuleFor(message => message.CreationDate)
            .Must(date => date <= DateTime.UtcNow)
                .WithMessage("Creation date must be a valid date.");
    }
}