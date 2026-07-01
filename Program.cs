using Microsoft.EntityFrameworkCore;
using RSConnect.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Lê a connection string da variável de ambiente do Railway
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Registra o DbContext usando PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);

// Ativa controllers
builder.Services.AddControllers();

// Ativa CORS (para permitir acesso do front-end)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Rota para abrir o HTML de cadastro
app.MapGet("/cadastro-usuario", async context =>
{
    await context.Response.SendFileAsync(Path.Combine("cadastro", "usuario.html"));
});

// Ativa as rotas dos controllers
app.MapControllers();

app.Run();
