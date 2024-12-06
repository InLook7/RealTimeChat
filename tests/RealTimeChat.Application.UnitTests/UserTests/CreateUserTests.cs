using Xunit;
using NSubstitute;
using RealTimeChat.Application.Features.Users.Create;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.UnitTests.UserTests;

public class CreateUserTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateUserHandler _handler;

    public CreateUserTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _handler = new CreateUserHandler(_unitOfWork);
    }

    [Fact]
    public async Task CreateUser_ReturnsUserDto()
    {
        // Arrange
        var command = new CreateUserCommand("TestUser");

        _unitOfWork.UserRepository.CreateAsync(Arg.Any<User>())
            .Returns(Task.CompletedTask);
        _unitOfWork.SaveAsync()
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _unitOfWork.UserRepository.Received(1).CreateAsync(Arg.Any<User>());
        await _unitOfWork.Received(1).SaveAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }
}