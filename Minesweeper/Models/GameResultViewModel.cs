namespace Minesweeper.Models;

public record GameResultViewModel
{
    public string Name { get; set; }
    public int Score { get; set; }
    public TimeSpan Time { get; set; }
    public uint AreaWidth { get; set; }
    public uint AreaHeight { get; set; }
    public uint Mines { get; set; }
}