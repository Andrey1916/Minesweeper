using Minesweeper.DataAccess.Repositories;
using Minesweeper.Services.Dto;
using Entities = Minesweeper.DataAccess.Entities;

namespace Minesweeper.Services.Services;

public class GameResultService : IGameResultService
{
    private readonly IRepository<Entities.GameResult, Guid> _repository;

    public GameResultService(IRepository<Entities.GameResult, Guid> repository)
    {
        _repository = repository ?? throw new NullReferenceException(nameof(repository));
    }

    public GameResult? Get(Guid id)
    {
        var result = _repository.Get(id);
        return result is null
            ? null
            : EntityToDto(result);
    }

    public async Task<GameResult?> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        return result is null
            ? null
            : EntityToDto(result);
    }

    public IEnumerable<GameResult> Get()
    {
        var results = _repository.Get();
        return results.Select(EntityToDto);
    }

    public async Task<IEnumerable<GameResult>> GetAsync()
    {
        var results = await _repository.GetAsync();
        return results.Select(EntityToDto);
    }


    public IEnumerable<GameResult> Get(int skip, int take)
    {
        var results = _repository.Get(skip, take);
        return results.Select(EntityToDto);
    }

    public async Task<IEnumerable<GameResult>> GetAsync(int skip, int take)
    {
        var results = await _repository.GetAsync(skip, take);
        return results.Select(EntityToDto);
    }

    public void Add(NewGameResult result)
    {
        if (result is null)
        {
            throw new NullReferenceException(nameof(result));
        }

        var entity = new Entities.GameResult
        {
            Id         = result.Id,
            Mines      = result.Mines,
            Name       = result.Name,
            Time       = result.Time,
            AreaHeight = result.AreaHeight,
            AreaWidth  = result.AreaWidth,
            Score      = CalcScore(result.Time, result.AreaWidth, result.AreaHeight, result.Mines)
        };

        _repository.Add(entity);
    }

    public async Task AddAsync(NewGameResult result)
    {
        if (result is null)
        {
            throw new NullReferenceException(nameof(result));
        }

        var entity = new Entities.GameResult
        {
            Id         = result.Id,
            Mines      = result.Mines,
            Name       = result.Name,
            Time       = result.Time,
            AreaHeight = result.AreaHeight,
            AreaWidth  = result.AreaWidth,
            Score      = CalcScore(result.Time, result.AreaWidth, result.AreaHeight, result.Mines)
        };

        await _repository.AddAsync(entity);
    }

    private static GameResult EntityToDto(Entities.GameResult entity)
    {
        return new GameResult
        {
            Id         = entity.Id,
            Mines      = entity.Mines,
            Name       = entity.Name,
            AreaHeight = entity.AreaHeight,
            AreaWidth  = entity.AreaWidth,
            Time       = TimeSpan.FromSeconds(entity.Time),
            Score      = entity.Score
        };
    }

    private static int CalcScore(long time, uint width, uint height, uint mines)
    {
        return (int)(width * height * mines / time);
    }
}