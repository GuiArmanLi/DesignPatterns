using CompositeWeb.models;
using Microsoft.EntityFrameworkCore;

namespace CompositeWeb.data;

public class AppDbContext : DbContext
{
    private IConfiguration _configuration;
    public DbSet<User> Users { get; set; }

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = _configuration.GetConnectionString("MySql");
        optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 36)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
    }
}