using System.Text.Json.Serialization;
using CompositeWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CompositeWeb.Data.Mapper;

public class BookMapper : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Image).IsRequired();
        builder.Property(b => b.Chapters).IsRequired();
        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Describe).IsRequired();
        builder.Property(b => b.Genres).IsRequired();
        builder.Property(b => b.Title).IsRequired();
        
        builder.HasIndex(b => b.Title).IsUnique();
        builder.HasIndex(b => b.Image).IsUnique();
        builder.HasIndex(b => b.PositionInRank).IsUnique();

        builder.Property(b => b.Title).HasMaxLength(50);
        builder.Property(b => b.Author).HasMaxLength(50);
        builder.Property(b => b.Describe).HasMaxLength(500);

        builder.Property(b => b.Chapters)
            .HasConversion<string>(c => JsonConvert.SerializeObject(c),
                c => JsonConvert.DeserializeObject<List<Chapter>>(c)!);
    }
}