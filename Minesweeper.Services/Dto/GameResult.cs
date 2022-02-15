namespace Minesweeper.Services.Dto;

public record GameResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public TimeSpan Time { get; set; }
    public uint AreaWidth { get; set; }
    public uint AreaHeight { get; set; }
    public uint Mines { get; set; }
}