using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<RealTimeChatDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RealTimeChatDbConnectionString"));
        });

        return services;
    }
}