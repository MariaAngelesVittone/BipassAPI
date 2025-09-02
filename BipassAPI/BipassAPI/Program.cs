using Domain.Interfaces;
using Infraestructure;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Registrar DbContext con SQLite
builder.Services.AddDbContext<BipassDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BipassDBConnectionString");
    options.UseSqlite(connectionString);
});

// 🔹 Registrar repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
