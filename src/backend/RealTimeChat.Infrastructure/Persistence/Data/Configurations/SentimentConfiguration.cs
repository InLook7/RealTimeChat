using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Infrastructure.Persistence.Data.Configurations;

public class SentimentConfiguration : IEntityTypeConfiguration<Sentiment>
{
    public void Configure(EntityTypeBuilder<Sentiment> builder)
    {
        builder.Property(u => u.SentimentResult)
            .HasMaxLength(30);
    }
}