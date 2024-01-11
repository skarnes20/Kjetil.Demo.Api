namespace Kjetil.Demo.DataAccess;

public sealed class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options)
    {
        if (Database.IsSqlite())
        {
            Database.EnsureCreated();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }

    public DbSet<WeatherEntity> Weather { get; set; }
}