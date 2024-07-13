using System.Diagnostics;
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

    public async Task<TEntity?> FindByProperty(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).FirstOrDefaultAsync();
    }

    //Usar tratamento na futura service
    public async Task<TEntity?>
        RegisterEntity(TEntity? entity, Expression<Func<TEntity, bool>>? predicate = null) //Predicate
    {
        if (entity == null) throw new Exception("Entidade nula");
        
        var response = await _dbSet
            .Where(predicate!)
            .FirstOrDefaultAsync();

        if (response != null) throw new Exception("Entidade ja existente");

        await _dbSet.AddAsync(entity); // Colocar supressao na service
        await _context.SaveChangesAsync();

        return entity;
    }


    public async Task<TEntity?> UpdateEntity(Guid id, TEntity? request) // Corrigir repeticao permitida
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null || request == null) return request;

        _dbSet.Entry(entity).CurrentValues.SetValues(request);
        await _context.SaveChangesAsync();

        return request;
    }

    public async Task<TEntity?> DeleteEntityById(Guid request)
    {
        var entity = await _dbSet.FindAsync(request);
        if (entity != null) _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}