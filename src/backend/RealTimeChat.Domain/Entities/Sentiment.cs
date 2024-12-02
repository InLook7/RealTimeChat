using RealTimeChat.Domain.Common;

namespace RealTimeChat.Domain.Entities;

public class Sentiment : BaseEntity
{
    public int MessageId { get; set; }
    public required string SentimentResult { get; set; }
    public double PositiveScore { get; set; }
    public double NeutralScore { get; set; }
    public double NegativeScore { get; set; }

    // Navigation properties
    public Message? Message { get; set; }
}