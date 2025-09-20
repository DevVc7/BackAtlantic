using Estacionamiento.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Estacionamiento.Infraestructura.IRepositorios;
using Estacionamiento.Infraestructura.Repositorios;
using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Aplicacion.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BibliotecaDbContext")
    ?? throw new InvalidOperationException("Connection string 'BibliotecaDbContext' not found.");

builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(connectionString, 
        b => b.MigrationsAssembly("Biblioteca.Infraestructura")));

// Inyección de dependencias de repositorios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

// Inyección de dependencias de servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
