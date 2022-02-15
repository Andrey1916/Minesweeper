using Microsoft.EntityFrameworkCore;
using Minesweeper.DataAccess.Entities;

namespace Minesweeper.DataAccess.Repositories;

public class GameResultRepositories : IRepository<GameResult, Guid>
{
    private readonly DbContext _context;

    public GameResultRepositories(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));;
    }


    public GameResult? Get(Guid id)
    {
        return _context.Set<GameResult>()
                       .Find(id);
    }

    public async Task<GameResult?> GetAsync(Guid id)
    {
        return await _context.Set<GameResult>()
                             .FindAsync(id);
    }

    public IEnumerable<GameResult> Get()
    {
        return _context.Set<GameResult>()
                       .OrderByDescending(r => r.Score)
                       .AsNoTracking()
                       .ToList();
    }

    public async Task<IEnumerable<GameResult>> GetAsync()
    {
        return await _context.Set<GameResult>()
                             .OrderByDescending(r => r.Score)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public IEnumerable<GameResult> Get(int skip, int take)
    {
        return _context.Set<GameResult>()
                       .OrderByDescending(r => r.Score)
                       .AsNoTracking()
                       .Skip(skip)
                       .Take(take)
                       .ToList();
    }

    public async Task<IEnumerable<GameResult>> GetAsync(int skip, int take)
    {
        return await _context.Set<GameResult>()
                             .OrderByDescending(r => r.Score)
                             .AsNoTracking()
                             .Skip(skip)
                             .Take(take)
                             .ToListAsync();
    }

    public void Add(GameResult entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public async Task AddAsync(GameResult entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void Remove(GameResult entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public async Task RemoveAsync(GameResult entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Remove(Guid id)
    {
        var entity = _context.Set<GameResult>()
                             .Find(id);
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await _context.Set<GameResult>()
                                   .FindAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}