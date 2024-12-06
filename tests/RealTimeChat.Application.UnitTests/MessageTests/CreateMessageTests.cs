using Xunit;
using NSubstitute;
using FluentValidation;
using FluentValidation.Results;
using RealTimeChat.Application.Features.Messages.Create;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Domain.Entities;
using FluentAssertions;

namespace RealTimeChat.Application.UnitTests.MessageTests;

public class CreateMessageTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateMessageCommand> _validator;
    private readonly CreateMessageHandler _handler;

    public CreateMessageTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _validator = Substitute.For<IValidator<CreateMessageCommand>>();
        _handler = new CreateMessageHandler(_unitOfWork, _validator);
    }

    [Fact]
    public async Task CreateValidMessage_ReturnsMessageDto()
    {
        // Arrange
        var command = new CreateMessageCommand("Content", 1, 1, DateTime.UtcNow);

        _validator.ValidateAsync(Arg.Any<CreateMessageCommand>(), CancellationToken.None)
            .Returns(new ValidationResult());
        _unitOfWork.MessageRepository.CreateAsync(Arg.Any<Message>())
            .Returns(Task.CompletedTask);
        _unitOfWork.SaveAsync()
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _validator.Received(1).ValidateAsync(Arg.Any<CreateMessageCommand>(), CancellationToken.None);
        await _unitOfWork.MessageRepository.Received(1).CreateAsync(Arg.Any<Message>());
        await _unitOfWork.Received(1).SaveAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public async Task CreateInvalidMessage_ReturnsFail()
    {
        // Arrange
        var command = new CreateMessageCommand("Content", 1, 1, DateTime.UtcNow.AddMinutes(-1));

        _validator.ValidateAsync(Arg.Any<CreateMessageCommand>(), CancellationToken.None)
            .Returns(new ValidationResult([new ValidationFailure()]));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _validator.Received(1).ValidateAsync(Arg.Any<CreateMessageCommand>(), CancellationToken.None);

        Assert.True(result.IsFailed);
    }
}