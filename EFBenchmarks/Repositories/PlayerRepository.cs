using Database;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace EFBenchmarks.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private EfBenchmarksDbContext _context;

    public PlayerRepository(EfBenchmarksDbContext context)
    {
        _context = context;
    }

    public async Task<Player?> Get(Guid entityId)
    {
        return await _context.Players.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    public async Task<List<Player?>> List()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<Player?> Update(Player? player)
    {
        var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);

        if (existingPlayer != null)
        {
            _context.Players.Update(player);

            var entitiesUpdated = await _context.SaveChangesAsync();

            if (entitiesUpdated > 0)
            {
                return await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);
            }
        }
        
        return null;
    }

    public async Task<Player?> Create(Player player)
    {
        var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);

        if (existingPlayer == null)
        {
            await _context.Players.AddAsync(player);

            var entitiesUpdated = await _context.SaveChangesAsync();

            if (entitiesUpdated > 0)
            {
                return await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);
            }
        }

        return null;
    }

    public async Task<bool?> Delete(Guid playerId)
    {
        var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);

        if (existingPlayer == null)
        { 
            _context.Players.Remove(existingPlayer);

            var entitiesUpdated = await _context.SaveChangesAsync();

            return entitiesUpdated > 0;
        }

        return null;
    }
}

public interface IPlayerRepository : IBaseRepository<Player>
{
    
}

public interface IBaseRepository<T>
{
    public Task<T?> Get(Guid entityId);
    public Task<List<T?>> List();
    public Task<T?> Update(T entity);
    public Task<T?> Create(T entity);
    public Task<bool?> Delete(Guid entityId);
}
