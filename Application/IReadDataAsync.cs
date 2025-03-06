using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public interface IReadDataAsync<T, in TId> where T : class, IEntity<TId>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(TId id);
    IQueryable<T> Entities { get; }        
}
