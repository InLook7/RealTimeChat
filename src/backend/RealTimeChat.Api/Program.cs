using RealTimeChat.Api.Endpoints;
using RealTimeChat.Api.Hubs;
using RealTimeChat.Api.Middleware;
using RealTimeChat.Application.Extensions;
using RealTimeChat.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddSignalR();

builder.Services.AddOpenApi();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapRoomEndpoints();
app.MapUserEndpoints();

app.MapHub<ChatHub>("chat");

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.Run();