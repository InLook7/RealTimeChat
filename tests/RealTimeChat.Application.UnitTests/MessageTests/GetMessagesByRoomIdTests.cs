using Xunit;
using NSubstitute;
using FluentAssertions;
using RealTimeChat.Application.Features.Messages.GetByRoomId;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Application.UnitTests.Helpers.Providers;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.UnitTests.MessageTests;

public class GetMessagesByRoomIdTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly GetMessagesByRoomIdHandler _handler;

    public GetMessagesByRoomIdTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _handler = new GetMessagesByRoomIdHandler(_unitOfWork);
    }

    [Fact]
    public async Task GetMessagesByExistingRoomId_ReturnsMessagesDtos()
    {
        // Arrange
        var existingMessages = MessageDataProvider.GetMessages();
        var existingRoom = RoomDataProvider.GetRoom();

        _unitOfWork.RoomRepository.GetByIdAsync(existingRoom.Id)
            .Returns(existingRoom);
        _unitOfWork.MessageRepository.GetByRoomIdAsync(existingRoom.Id)
            .Returns(existingMessages);

        // Act
        var result = await _handler.Handle(new GetMessagesByRoomIdQuery(existingRoom.Id), CancellationToken.None);

        // Assert
        await _unitOfWork.RoomRepository.Received(1).GetByIdAsync(existingRoom.Id);

        Assert.NotNull(result.Value);
        Assert.Equal(existingMessages.Count(), result.Value.Count());
        result.Value.Should().BeEquivalentTo(existingMessages.ToMessageDtos());
    }

    [Fact]
    public async Task GetMessagesByNotExistingRoomId_ReturnsFail()
    {
        // Arrange
        var existingMessages = MessageDataProvider.GetMessages();
        var existingRoom = RoomDataProvider.GetRoom();

        _unitOfWork.RoomRepository.GetByIdAsync(existingRoom.Id)
            .Returns((Room)null);

        // Act
        var result = await _handler.Handle(new GetMessagesByRoomIdQuery(existingRoom.Id), CancellationToken.None);

        // Assert
        await _unitOfWork.RoomRepository.Received(1).GetByIdAsync(existingRoom.Id);

        Assert.True(result.IsFailed);
    }
}