using RealTimeChat.Application.Common.Dtos;

namespace RealTimeChat.Application.UnitTests.Helpers.Providers;

public static class SentimentDataProvider
{
    public static SentimentAnalysisDto GetSentiment()
    {
        return new SentimentAnalysisDto { SentimentResult = "Positive", 
            PositiveScore = 0.8, NeutralScore = 0.1, NegativeScore = 0.1 };
    }
}