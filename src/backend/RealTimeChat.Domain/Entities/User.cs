using RealTimeChat.Domain.Common;

namespace RealTimeChat.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }

    // Navigation properties
    public ICollection<Message>? Messages { get; set; }
}