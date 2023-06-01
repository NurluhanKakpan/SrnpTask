using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistence;

public static class PersistenceInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISrnpResultService, SrnpResultService>();
        services.AddScoped<ISrnpInfoRepository, SrnpInfoRepository>();
        services.AddScoped<ISrnpPriceRepository, SrnpPriceRepository>();
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        return services;
    }
}