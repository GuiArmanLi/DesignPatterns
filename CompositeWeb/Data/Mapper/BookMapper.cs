using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using CompositeWeb.Domain.Models;
using Newtonsoft.Json;

namespace CompositeWeb.Data.Mapper;

public class BookMapper : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.Describe).IsRequired();
        builder.Property(b => b.Image).IsRequired();
        builder.Property(b => b.Chapters).IsRequired();
        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Genres).IsRequired();

        builder.HasIndex(b => b.Title).IsUnique();
        builder.HasIndex(b => b.Image).IsUnique();
        builder.HasIndex(b => b.PositionInRank).IsUnique();

        builder.Property(b => b.Title).HasMaxLength(100);
        builder.Property(b => b.Image).HasMaxLength(500);
        builder.Property(b => b.Author).HasMaxLength(500);
        builder.Property(b => b.Describe).HasMaxLength(750);


        var valueComparer = new ValueComparer<List<Chapter>>(
            (c1, c2) =>
                JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => JsonConvert.DeserializeObject<List<Chapter>>(JsonConvert.SerializeObject(c))!
        );

        builder.Property(b => b.Chapters).HasConversion<string>(c =>
                JsonConvert.SerializeObject(c), c =>
                JsonConvert.DeserializeObject<List<Chapter>>(c)!)
            .Metadata.SetValueComparer(valueComparer);

        var authorComparer = new ValueComparer<List<Author>>(
            (a1, a2) => JsonConvert.SerializeObject(a1) == JsonConvert.SerializeObject(a2),
            a => a.Aggregate(0, (ac, av) => HashCode.Combine(ac, av.GetHashCode())),
            a => JsonConvert.DeserializeObject<List<Author>>(JsonConvert.SerializeObject(a))!
        );

        builder.Property(b => b.Author).HasConversion<string>(a =>
                JsonConvert.SerializeObject(a), a =>
                JsonConvert.DeserializeObject<List<Author>>(a)!)
            .Metadata.SetValueComparer(authorComparer);

        var commentComparer = new ValueComparer<List<Comment>>(
            (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => JsonConvert.DeserializeObject<List<Comment>>(JsonConvert.SerializeObject(c))!
        );

        builder.Property(b => b.Comments).HasConversion<string>(c =>
                JsonConvert.SerializeObject(c), c =>
                JsonConvert.DeserializeObject<List<Comment>>(c) ?? new List<Comment>())
            .Metadata.SetValueComparer(commentComparer);
    }
}