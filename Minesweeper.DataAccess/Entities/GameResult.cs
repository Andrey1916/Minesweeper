using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minesweeper.DataAccess.Entities;

/// <summary>
/// Game results
/// </summary>
public record GameResult : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// Time in seconds
    /// </summary>
    public long Time { get; set; }
    public int Score { get; set; }
    public uint AreaWidth { get; set; }
    public uint AreaHeight { get; set; }
    public uint Mines { get; set; }
}

public class GameResultConfiguration : IEntityTypeConfiguration<GameResult>
{
    public void Configure(EntityTypeBuilder<GameResult> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(512)
               .IsUnicode();

        builder.Property(p => p.Time)
               .IsRequired();

        builder.Property(p => p.AreaWidth)
               .IsRequired();

        builder.Property(p => p.AreaHeight)
               .IsRequired();

        builder.Property(p => p.Mines)
               .IsRequired();
    }
}