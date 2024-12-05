using FluentResults;
using MediatR;
using RealTimeChat.Application.Common.Mappers;
using RealTimeChat.Application.Contracts;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Features.Sentiments.Create;

public class CreateSentimentHandler : IRequestHandler<CreateSentimentCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITextAnalyticsService _textAnalyticsService;

    public CreateSentimentHandler(IUnitOfWork unitOfWork, ITextAnalyticsService textAnalyticsService)
    {
        _unitOfWork = unitOfWork;
        _textAnalyticsService = textAnalyticsService;
    }

    public async Task<Result<string>> Handle(CreateSentimentCommand command, CancellationToken cancellationToken)
    {
        var sentimentAnalysis = await _textAnalyticsService.AnalyzeSentimentAsync(command.Content);

        var sentiment = new Sentiment
        {
            MessageId = command.MessageId,
            SentimentResult = sentimentAnalysis.SentimentResult,
            PositiveScore = sentimentAnalysis.PositiveScore,
            NeutralScore = sentimentAnalysis.NeutralScore,
            NegativeScore = sentimentAnalysis.NegativeScore
        };

        await _unitOfWork.SentimentRepository.CreateAsync(sentiment);
        await _unitOfWork.SaveAsync();

        return Result.Ok(sentiment.SentimentResult);
    }
}