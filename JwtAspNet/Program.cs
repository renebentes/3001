using JwtAspNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

builder
    .Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.PrivateKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        });
builder.Services.AddAuthorization(options =>
{
    // As políticas são tratadas como string e assim como tal,
    // tratadas como case-sensitive. Constantes são recomendadas
    // (talvez enums?)
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", (TokenService tokenService) =>
{
    var user = new User(1,
        "Rene Bentes Pinto",
        "renebentes@xyz.com",
        "123456",
        "https://profile.photo",
        ["student", "premium"]);
    return tokenService.Create(user);
});

app.MapGet("/restrito", () => "Acesso permitido!")
   .RequireAuthorization();

app.MapGet("/admin", () => "Você é admin!")
   .RequireAuthorization("admin");

app.Run();
