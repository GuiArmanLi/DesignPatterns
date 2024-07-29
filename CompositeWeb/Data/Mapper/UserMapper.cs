using CompositeWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompositeWeb.Data.Mapper;

public class UserMapper : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(u => u.Name).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Password).IsRequired();

        builder.Property(u => u.Name).HasMaxLength(12);
        builder.Property(u => u.Email).HasMaxLength(30);
        builder.Property(u => u.Password).HasMaxLength(150);
    }
}