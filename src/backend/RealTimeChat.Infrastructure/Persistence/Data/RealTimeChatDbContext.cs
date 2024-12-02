using Microsoft.EntityFrameworkCore;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data.Configurations;

namespace RealTimeChat.Infrastructure.Persistence.Data;

public class RealTimeChatDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Sentiment> Sentiments { get; set; }

    public RealTimeChatDbContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new SentimentConfiguration());
    }
}