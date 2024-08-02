using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Mapper;

public class ChapterMapper : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasNoKey();
        
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Images).IsRequired();
        builder.Property(c => c.NumberOfChapter).IsRequired();

        builder.HasIndex(c => c.NumberOfChapter).IsUnique();
        builder.HasIndex(c => c.PreviousChapter).IsUnique();
        builder.HasIndex(c => c.NextChapter).IsUnique();

        builder.Property(c => c.Title).HasMaxLength(75);
    }
}