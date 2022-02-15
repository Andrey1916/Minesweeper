namespace Minesweeper.Services.Dto;

public record NewGameResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Time { get; set; }
    public uint AreaWidth { get; set; }
    public uint AreaHeight { get; set; }
    public uint Mines { get; set; }
}