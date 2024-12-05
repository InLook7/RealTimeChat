using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChat.Blazor;
using RealTimeChat.Blazor.Handlers.Interfaces;
using RealTimeChat.Blazor.Handlers.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(serviceProdiver => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5131")
});

builder.Services.AddSingleton(serviceProvider =>
    new HubConnectionBuilder()
        .WithUrl("http://localhost:5131/chat")
        .Build()
);

builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<IHubService, HubService>();

await builder.Build().RunAsync();
