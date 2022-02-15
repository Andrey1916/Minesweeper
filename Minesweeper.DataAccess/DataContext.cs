using Microsoft.EntityFrameworkCore;
using Minesweeper.DataAccess.Entities;

namespace Minesweeper.DataAccess;

public sealed class DataContext : DbContext
{
    public DbSet<GameResult> GameResults { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameResult>()
                    .ToTable("GameResults");
        modelBuilder.ApplyConfiguration(new GameResultConfiguration());

        InitializeDatabase(modelBuilder);
    }

    private static void InitializeDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameResult>()
            .HasData(
                new GameResult
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 1",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 10,
                    AreaWidth  = 10,
                    Mines      = 10,
                    Score      = 15
                },
                new GameResult
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 2",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 20,
                    AreaWidth  = 20,
                    Mines      = 10,
                    Score      = 12
                },
                new GameResult
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 3",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 50,
                    AreaWidth  = 25,
                    Mines      = 10,
                    Score      = 12
                },
                new GameResult
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 4",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 50,
                    AreaWidth  = 50,
                    Mines      = 10,
                    Score      = 11
                },
                new GameResult
                {
                    Id         = Guid.NewGuid(),
                    Name       = "User 5",
                    Time       = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    AreaHeight = 100,
                    AreaWidth  = 100,
                    Mines      = 10,
                    Score      = 10
                });
    }
}