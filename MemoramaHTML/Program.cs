using MemoramaHTML.Models.Entities;
using MemoramaHTML.Repository;
using MemoramaHTML.Services;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
//   CONFIGURAR SERVICIOS
// ----------------------

builder.Services.AddControllers();

// Tu DBContext
builder.Services.AddDbContext<MemoramaContext>();

// Repository genérico
builder.Services.AddScoped(typeof(Repository<>), typeof(Repository<>));

// Servicios
builder.Services.AddScoped<MemoramaService>();
builder.Services.AddScoped<ResultadosService>();

// ----------------------
//   CONSTRUIR APP
// ----------------------

var app = builder.Build();

// Permitir servir HTML, CSS, JS
app.UseFileServer();

// Activar API Controllers
app.MapControllers();

app.Run();
