using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services.Dto;
using Minesweeper.Services.Services;

namespace Minesweeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameResultController : ControllerBase
{
    private readonly ILogger<GameResultController> _logger;
    private readonly IGameResultService _service;

    public GameResultController(
        ILogger<GameResultController> logger,
        IGameResultService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<GameResultViewModel>> Get(int skip, int take)
    {
        try
        {
            var results = await _service.GetAsync(skip, take);
            return results.Select(
                r => new GameResultViewModel
                {
                    Mines      = r.Mines,
                    Name       = r.Name,
                    Score      = r.Score,
                    Time       = r.Time,
                    AreaHeight = r.AreaHeight,
                    AreaWidth  = r.AreaWidth
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    [HttpPost]
    public async Task Post([FromBody] GameResultAddRequest request)
    {
        try
        {
            var result = new NewGameResult
            {
                Mines      = request.Mines,
                Name       = request.Name,
                Time       = request.Time,
                AreaHeight = request.AreaHeight,
                AreaWidth  = request.AreaWidth
            };

            await _service.AddAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}