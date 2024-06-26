﻿using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public abstract class RepositoryBase<TEntity, TId>(MajornaDbContext context) : IService<TEntity, TId> 
    where TEntity : class
{
    protected readonly MajornaDbContext _context = context;

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _context.Entry(entity).ReloadAsync();

        return entity;
    }

    //Needs to be implemented in each child class
    public abstract Task<bool> UpdateAsync(TEntity entity);

    public virtual async Task<bool> DeleteAsync(TId id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity is null)
        {
            return false;
        }
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }


}