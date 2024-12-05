using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using RealTimeChat.Application.Features.Messages.Create;
using RealTimeChat.Application.Contracts;

namespace RealTimeChat.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddTransient<IValidator<CreateMessageCommand>, CreateMessageValidator>();

        return services;
    }
}