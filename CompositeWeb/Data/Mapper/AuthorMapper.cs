using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Mapper;

public class AuthorMapper : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasNoKey();

        builder.Property(a => a.Name).IsRequired();

        builder.HasIndex(a => a.Name).IsUnique();

        builder.Property(a => a.Name).HasMaxLength(100);
        builder.Property(a => a.Biography).HasMaxLength(150);
        builder.Property(a => a.Nationality).HasMaxLength(50);
    }
}