using MediatR;
using FluentResults;
using RealTimeChat.Shared.Dtos;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Contracts.UnitOfWork;

namespace RealTimeChat.Application.Features.Messages.GetByRoomId;

public class GetMessagesByRoomIdHandler : IRequestHandler<GetMessagesByRoomIdQuery, Result<IEnumerable<MessageDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMessagesByRoomIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<MessageDto>>> Handle(GetMessagesByRoomIdQuery query, CancellationToken cancellationToken)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(query.RoomId);
        if (room == null)
        {
            return Result.Fail($"Room '{query.RoomId}' does not exist.");
        }

        var messages = await _unitOfWork.MessageRepository.GetByRoomIdAsync(query.RoomId);
        
        return Result.Ok(messages.ToMessageDto());
    }
}