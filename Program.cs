using api_acesso_ia;
using api_acesso_ia.Repositories.Interfaces;
using api_acesso_ia.Repositories;
using api_acesso_ia.Services.Interfaces;
using api_acesso_ia.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurando DB Mysql
var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.
        AddDbContext<AppDbContext>(op =>
        op.UseMySql(connectionString,
        ServerVersion.Parse("5.7.0")));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
