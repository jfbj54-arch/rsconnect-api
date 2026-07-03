using Microsoft.EntityFrameworkCore;
using RSConnect.API.Data;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL + Railway
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Executa migrations automaticamente no Railway
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();

// IMPORTANTE: NÃO DEFINA PORTA MANUALMENTe
app.Run();

