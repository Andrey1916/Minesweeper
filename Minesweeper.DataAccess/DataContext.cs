using Microsoft.EntityFrameworkCore;
using Minesweeper.DataAccess.Entities;

namespace Minesweeper.DataAccess;

public sealed class DataContext : DbContext
{
    public DbSet<Score> Scores { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ScoreConfiguration());

        InitializeDatabase(modelBuilder);
    }

    private static void InitializeDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Score>()
            .HasData(
                new Score
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 1",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 10,
                    AreaWidth  = 10
                },
                new Score
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 2",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 20,
                    AreaWidth  = 20
                },
                new Score
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 3",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 50,
                    AreaWidth  = 25
                },
                new Score
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 4",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 50,
                    AreaWidth  = 50
                },
                new Score
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 5",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 100,
                    AreaWidth  = 100
                });
    }
}