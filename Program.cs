using Microsoft.EntityFrameworkCore;
using rsconnect_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with Railway connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Enable Swagger in production
app.UseSwagger();
app.UseSwaggerUI();

// Map controllers
app.MapControllers();

app.Run();
