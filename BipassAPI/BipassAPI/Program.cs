using Application.Interfaces;
using Domain.Interfaces;
using Infraestructure;
using Infraestructure.Repositories;
using Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar DbContext con SQLite
builder.Services.AddDbContext<BipassDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BipassDBConnectionString");
    options.UseSqlite(connectionString);
});

// Registrar repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registrar el servicio de autenticación
builder.Services.AddScoped<ICustomAuthenticationService, AuthenticationService>();

// Registrar el UserService 
builder.Services.AddScoped<Application.Services.UserService>();

// Registrar las opciones de configuración para el servicio de autenticación
builder.Services.Configure<AuthenticationService.AuthenticationsServiceOptions>(
    builder.Configuration.GetSection("AuthenticationService")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run(); ;