using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models;

public record GameResultAddRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public long Time { get; set; }

    [Required]
    public uint AreaWidth { get; set; }

    [Required]
    public uint AreaHeight { get; set; }

    [Required]
    public uint Mines { get; set; }
}