using System.Linq.Expressions;
using CompositeWeb.Data.Context;
using CompositeWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CompositeWeb.data.Repositories;

public class BaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> FindAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> FindById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity?> FindByPropertyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity?>
        RegisterEntityAsync(TEntity? entity, Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (entity is null)
            return null;

        var response = await _dbSet
            .Where(predicate!)
            .FirstOrDefaultAsync();

        if (response != null)
            return null;

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }


    public async Task<TEntity?> UpdateEntityAsync(Guid id, TEntity? request)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null || request is null) return null;

        var propertiesToChange = new List<string>() { "Name", "Password", "Email" };
        foreach (var property in typeof(TEntity).GetProperties())
        {
            var requestValue = property.GetValue(request);
            if (requestValue != null && propertiesToChange.Contains(property.Name))
            {
                property.SetValue(entity, requestValue);
            }
        }

        _context.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity?> DeleteEntityByIdAsync(Guid request)
    {
        var entity = await _dbSet.FindAsync(request);

        if (entity is null)
            return null;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}