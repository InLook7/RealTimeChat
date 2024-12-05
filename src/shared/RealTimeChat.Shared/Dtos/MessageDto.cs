namespace RealTimeChat.Shared.Dtos;

public class MessageDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Sentiment { get; set; }
}