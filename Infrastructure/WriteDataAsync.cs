using Application;
using Athena.Data;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

internal class WriteDataAsync<T, TId> : IWriteDataAsync<T, TId> where T : BaseEntity<TId>
{
    private readonly AthenaContext _context;

    public WriteDataAsync(AthenaContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var entityToFind = await _context.Set<T>().FindAsync(entity.Id);
        _context.Entry(entityToFind).CurrentValues.SetValues(entity);
        return entity;
    }
}