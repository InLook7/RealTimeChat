using Asp.Versioning;
using Scalar.AspNetCore;
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

builder.Services.AddApiVersioning(options => 
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddOpenApi();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

var versionedGroup = app.NewVersionedApi()
    .MapGroup("api/v{version:apiVersion}")
    .HasApiVersion(1);

versionedGroup.MapRoomEndpoints();
versionedGroup.MapUserEndpoints();

app.MapHub<ChatHub>("chat");

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.Run();