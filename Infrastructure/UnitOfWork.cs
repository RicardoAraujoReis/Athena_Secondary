using Application;
using Athena.Data;
using Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

internal class UnitOfWork<TId> : IUnitOfWork<TId>
{
    private readonly AthenaContext _context;
    private bool disposed;
    private Hashtable _instances;

    public UnitOfWork(AthenaContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }        

    public IReadDataAsync<T, TId> ReadDataFor<T>() where T : BaseEntity<TId>
    {
        if (_instances == null)
        {
            _instances = new Hashtable();
        }

        var type = typeof(T).Name;

        if (!_instances.ContainsKey(type))
        {
            var instanceType = typeof(ReadDataAsync<,>);
            var instance = Activator.CreateInstance(instanceType.MakeGenericType(typeof(T), typeof(TId)), _context);
            _instances.Add(type, instance);
        }

        return (IReadDataAsync<T, TId>)_instances[type];
    }

    public IWriteDataAsync<T, TId> WriteDataFor<T>() where T : BaseEntity<TId>
    {
        if (_instances == null)
        {
            _instances = new Hashtable();
        }

        var type = typeof(T).Name;

        if (!_instances.ContainsKey(type))
        {
            var instanceType = typeof(WriteDataAsync<,>);
            var instance = Activator.CreateInstance(instanceType.MakeGenericType(typeof(T), typeof(TId)), _context);
            _instances.Add(type, instance);
        }

        return (IWriteDataAsync<T, TId>)_instances[type];
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                disposed = true;
            }
        }
        disposed = true;
    }
}
