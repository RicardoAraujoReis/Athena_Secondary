using Application;
using Athena.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddDatabase(this  IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        //return services.AddDbContext<AthenaContext>(options => options.UseSqlServer(connectionString));
        return services.AddDbContext<AthenaContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
    }        

    public static IServiceCollection AddInstances(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(IReadDataAsync<,>), typeof(ReadDataAsync<,>))
            .AddTransient(typeof(IWriteDataAsync<,>), typeof(WriteDataAsync<,>))
            .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}
