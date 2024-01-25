using JwtStore.Api.Extensions;
using JwtStore.Infrastructure.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurations()
                .AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
