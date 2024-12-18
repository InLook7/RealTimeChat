using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChat.Application.Contracts;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Infrastructure.Persistence.Data;
using RealTimeChat.Infrastructure.Persistence.UnitOfWork;
using RealTimeChat.Infrastructure.Services;

namespace RealTimeChat.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<RealTimeChatDbContext>(options =>
            options.UseSqlServer(configuration["RealTimeChatDbConnectionString"])
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient<ITextAnalyticsService, TextAnalyticsService>();

        services.AddSingleton(new TextAnalyticsClient(
            new Uri(configuration["TextAnalyticsEndpoint"]), 
            new AzureKeyCredential(configuration["TextAnalyticsApiKey"])
        ));

        return services;
    }
}