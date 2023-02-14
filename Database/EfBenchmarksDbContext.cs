using Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database;

public class EfBenchmarksDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public EfBenchmarksDbContext(DbContextOptions<EfBenchmarksDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public EfBenchmarksDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"));
    }
    
    public DbSet<Player> Players { get; set; }
}
