using JwtAspNet;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapGet("/", (TokenService tokenService) =>
{
    var user = new User(1,
        "Rene Bentes Pinto",
        "renebentes@xyz.com",
        "123456",
        "https://profile.photo",
        ["student", "premium"]);
    return tokenService.Create(user);
});

app.Run();
