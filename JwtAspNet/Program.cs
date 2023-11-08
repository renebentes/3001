using JwtAspNet;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapGet("/", (TokenService tokenService) => tokenService.Create());

app.Run();
