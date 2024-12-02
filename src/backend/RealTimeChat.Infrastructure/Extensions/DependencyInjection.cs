using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Infrastructure.Persistence.Data;
using RealTimeChat.Infrastructure.Persistence.UnitOfWork;

namespace RealTimeChat.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<RealTimeChatDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("RealTimeChatDbConnectionString"))
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}