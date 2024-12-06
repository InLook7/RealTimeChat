using Xunit;
using NSubstitute;
using FluentAssertions;
using RealTimeChat.Application.Features.Rooms.GetAll;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Application.UnitTests.Helpers.Providers;
using RealTimeChat.Application.Common.Mappers;

namespace RealTimeChat.Application.UnitTests.RoomTests;

public class GetAllRoomsTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly GetAllRoomsHandler _handler;

    public GetAllRoomsTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _handler = new GetAllRoomsHandler(_unitOfWork);
    }

    [Fact]
    public async Task GetAllRooms_ReturnsRoomDtos()
    {
        // Arrange
        var existingRooms = RoomDataProvider.GetRooms();

        _unitOfWork.RoomRepository.GetAllAsync()
            .Returns(existingRooms);

        // Act
        var rooms = await _handler.Handle(new GetAllRoomsQuery(), CancellationToken.None);

        // Assert
        await _unitOfWork.RoomRepository.Received(1).GetAllAsync();

        Assert.NotNull(rooms);
        Assert.Equal(existingRooms.Count(), rooms.Count());
        rooms.Should().BeEquivalentTo(existingRooms.ToRoomDtos());
    }
}