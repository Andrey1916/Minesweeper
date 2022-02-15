using Minesweeper.Services.Dto;

namespace Minesweeper.Services.Services;

public interface IGameResultService
{
    GameResult? Get(Guid id);
    Task<GameResult?> GetAsync(Guid id);

    IEnumerable<GameResult> Get();
    Task<IEnumerable<GameResult>> GetAsync();

    IEnumerable<GameResult> Get(int skip, int take);
    Task<IEnumerable<GameResult>> GetAsync(int skip, int take);

    public void Add(NewGameResult result);
    public Task AddAsync(NewGameResult result);
}