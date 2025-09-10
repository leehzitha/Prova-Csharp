using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using prova.Endpoints;
using prova.Models;
using prova.Services.JWT;
using prova.Services.Passeios;
using prova.Services.Password;
using prova.Services.Profile;
using prova.UseCases.Passeios.CreatePasseio;
using prova.UseCases.Passeios.EditPasseio;
using prova.UseCases.Passeios.GetPasseios;
using prova.UseCases.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProvaDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, EFPasswordService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IPasseioService, PasseioService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<CreatePasseioUseCase>();
builder.Services.AddTransient<EditPasseioUseCase>();
builder.Services.AddTransient<GetPasseiosUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "dtaplace",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureAuthEndpoints();
app.ConfigurePasseioEndpoints();
app.ConfigureUserEndpoints();

app.Run();