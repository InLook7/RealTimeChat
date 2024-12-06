using Xunit;
using NSubstitute;
using RealTimeChat.Application.Features.Sentiments.Create;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Application.Contracts;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Application.UnitTests.Helpers.Providers;

namespace RealTimeChat.Application.UnitTests.SentimentTests;

public class CreateSentimentTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITextAnalyticsService _textAnalyticsService;
    private readonly CreateSentimentHandler _handler;

    public CreateSentimentTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _textAnalyticsService = Substitute.For<ITextAnalyticsService>();
        _handler = new CreateSentimentHandler(_unitOfWork, _textAnalyticsService);
    }

    [Fact]
    public async Task CreateSentiment_ReturnsSentimentResult()
    {
        // Arrange
        var command = new CreateSentimentCommand(1, "Content");
        var sentiment = SentimentDataProvider.GetSentiment();

        _textAnalyticsService.AnalyzeSentimentAsync(command.Content)
            .Returns(sentiment);
        _unitOfWork.SentimentRepository.CreateAsync(Arg.Any<Sentiment>())
            .Returns(Task.CompletedTask);
        _unitOfWork.SaveAsync()
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _textAnalyticsService.Received(1).AnalyzeSentimentAsync(command.Content);
        await _unitOfWork.SentimentRepository.Received(1).CreateAsync(Arg.Any<Sentiment>());
        await _unitOfWork.Received(1).SaveAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }
}