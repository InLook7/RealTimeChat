using RealTimeChat.Application.Common.Dtos;

namespace RealTimeChat.Application.Contracts;

public interface ITextAnalyticsService
{
    Task<SentimentAnalysisDto> AnalyzeSentimentAsync(string text);
}