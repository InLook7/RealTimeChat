namespace RealTimeChat.Application.Common.Dtos;

public class SentimentAnalysisDto
{
    public string SentimentResult { get; set; }
    public double PositiveScore { get; set; }
    public double NeutralScore { get; set; }
    public double NegativeScore { get; set; }
}