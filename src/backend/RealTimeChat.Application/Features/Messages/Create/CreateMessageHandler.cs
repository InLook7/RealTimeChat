using MediatR;
using FluentResults;
using FluentValidation;
using RealTimeChat.Shared.Dtos;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.Features.Messages.Create;

public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, Result<MessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateMessageCommand> _validator;

    public CreateMessageHandler(IUnitOfWork unitOfWork, IValidator<CreateMessageCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<MessageDto>> Handle(CreateMessageCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var message = new Message
        {
            Content = command.Content,
            RoomId = command.RoomId,
            UserId = command.UserId,
            CreationDate = command.CreationDate,
        };

        await _unitOfWork.MessageRepository.CreateAsync(message);
        await _unitOfWork.SaveAsync();

        return Result.Ok(message.ToMessageDto());
    }
}