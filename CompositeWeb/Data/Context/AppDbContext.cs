using Microsoft.EntityFrameworkCore;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) //, IConfiguration configuration)
    : DbContext(options)
{
    public DbSet<User> Users { get; init; }
    public DbSet<Book> Books { get; init; }

    // private IConfiguration _configuration = configuration;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}