using Microsoft.EntityFrameworkCore;
using MiniMercado.Context;
using MiniMercado.Repositories;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conexaosql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(conexaosql,
    ServerVersion.AutoDetect(conexaosql)));

builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
