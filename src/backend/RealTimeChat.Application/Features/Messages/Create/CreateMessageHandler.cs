using Ardalis.Result;
using MediatR;
using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.Features.Messages.Create;

public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, Result<MessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMessageHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MessageDto>> Handle(CreateMessageCommand command, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            Content = command.Content,
            RoomId = command.RoomId,
            UserId = command.UserId,
            CreationDate = command.CreationDate
        };

        await _unitOfWork.MessageRepository.CreateAsync(message);
        await _unitOfWork.SaveAsync();

        return message.ToMessageDto();
    }
}