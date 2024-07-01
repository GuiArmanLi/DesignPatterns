using System.Linq.Expressions;
using CompositeWeb.Data.Context;
using CompositeWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CompositeWeb.data.Repositories;

public class BaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;

    private readonly DbSet<TEntity> _entity;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity?>> GetAllEntitiesQueryable(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _entity.AsQueryable();

        if (filter != null)
            query = query.Where(filter).AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetEntityByAttribute(Guid request)
    {
        return await _entity.FindAsync(request);
    }

    public async Task PostEntity(TEntity? request)
    {
        if (request != null) await _entity.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task PutEntity(TEntity? request)
    {
        if (request != null) _entity.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEntity(TEntity? request)
    {
        if (request != null) _entity.Remove(request);
        await _context.SaveChangesAsync();
    }
}