using RealTimeChat.Domain.Entities;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Common.Mappers;

public static class SentimentMapper
{
    public static SentimentDto ToSentimentDto(this Sentiment sentiment)
    {
        return new SentimentDto
        {
            Id = sentiment.Id,
            MessageId = sentiment.MessageId,
            PositiveScore = sentiment.PositiveScore,
            NeutralScore = sentiment.NeutralScore,
            NegativeScore = sentiment.NegativeScore
        };
    }

    public static IEnumerable<SentimentDto> ToSentimentDtos(this IEnumerable<Sentiment> sentiments)
    {
        return sentiments.Select(ToSentimentDto).ToList();
    }
}