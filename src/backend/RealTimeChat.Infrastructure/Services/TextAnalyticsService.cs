using Azure.AI.TextAnalytics;
using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Application.Contracts;

namespace RealTimeChat.Infrastructure.Services;

public class TextAnalyticsService : ITextAnalyticsService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;

    public TextAnalyticsService(TextAnalyticsClient textAnalyticsClient)
    {
        _textAnalyticsClient = textAnalyticsClient;
    }

    public async Task<SentimentAnalysisDto> AnalyzeSentimentAsync(string text)
    {
        var analysisResult = await _textAnalyticsClient.AnalyzeSentimentAsync(text);

        return new SentimentAnalysisDto
        {
            SentimentResult = analysisResult.Value.Sentiment.ToString(),
            PositiveScore = analysisResult.Value.ConfidenceScores.Positive,
            NeutralScore = analysisResult.Value.ConfidenceScores.Neutral,
            NegativeScore = analysisResult.Value.ConfidenceScores.Negative
        };
    }
}