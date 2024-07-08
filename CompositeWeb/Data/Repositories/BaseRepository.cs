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

    public async Task<List<TEntity>> GetAllEntities(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await _entity.ToListAsync();
    }

    public async Task<TEntity?> GetEntityById(Guid request)
    {
        return await _entity.FindAsync(request);
    }

    public async Task<TEntity?> PostEntity(TEntity? request, object[]? valuesToCompare)
    {
        if (valuesToCompare == null || request == null) return null;

        var entities = await _entity.ToListAsync();

        foreach (var entity in entities)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                foreach (var value in valuesToCompare)
                {
                    if (property.GetValue(entity)?.Equals(value) == true) return null;
                }
            }
        }

        await _entity.AddAsync(request);
        await _context.SaveChangesAsync();

        return request;
    }


    public async Task<TEntity?> PutEntity(Guid id, TEntity? request)
    {
        var entity = await _entity.FindAsync(id);

        if (entity == null || request == null) return request;
        request.Id = id;

        _entity.Entry(entity).CurrentValues.SetValues(request);
        await _context.SaveChangesAsync();

        return request;
    }


    public async Task<TEntity?> DeleteEntity(Guid request)
    {
        var entity = await _entity.FindAsync(request);
        if (entity != null) _entity.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}