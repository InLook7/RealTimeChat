using RealTimeChat.Domain.Common;

namespace RealTimeChat.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Message> Messages { get; set; }
}