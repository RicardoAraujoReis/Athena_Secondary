using Athena.Models;
using Common.Responses;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public interface IUnitOfWork<TId> : IDisposable
{
    IWriteDataAsync<T, TId> WriteDataFor<T>() where T : BaseEntity<TId>;
    IReadDataAsync<T, TId> ReadDataFor<T>() where T : BaseEntity<TId>;
    Task<int> CommitAsync(CancellationToken cancellationToken);    
}
