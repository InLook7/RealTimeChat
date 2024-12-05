using MediatR;
using RealTimeChat.Shared.Dtos;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Contracts.UnitOfWork;

namespace RealTimeChat.Application.Features.Rooms.GetAll;

public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRoomsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
    {
        var rooms = await _unitOfWork.RoomRepository.GetAllAsync();

        return rooms.ToRoomDtos();
    }
}