using MediatR;
using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Contracts.UnitOfWork;

namespace RealTimeChat.Application.Features.Messages.GetByRoomId;

public class GetMessagesByRoomIdHandler : IRequestHandler<GetMessagesByRoomIdQuery, IEnumerable<MessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMessagesByRoomIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MessageDto>> Handle(GetMessagesByRoomIdQuery query, CancellationToken cancellationToken)
    {
        var messages = await _unitOfWork.MessageRepository.GetByRoomIdAsync(query.RoomId);

        return messages.ToMessageDtos();
    }
}