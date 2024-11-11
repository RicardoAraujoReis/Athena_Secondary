using Application;
using Athena.Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class ReadDataAsync<T, TId> : IReadDataAsync<T, TId> where T : BaseEntity<TId>
{
    private readonly AthenaContext _context;

    public ReadDataAsync(AthenaContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(TId id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public IQueryable<T> Entities => _context.Set<T>();
}