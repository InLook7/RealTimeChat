using RealTimeChat.Domain.Common;

namespace RealTimeChat.Domain.Entities;

public class Message : BaseEntity
{
    public required string Content { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public DateTime CreationDate { get; set; }

    // Navigation properties
    public Room? Room { get; set; }
    public User? User { get; set; }
    public Sentiment? Sentiment { get; set; }
}