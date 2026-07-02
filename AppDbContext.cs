using Microsoft.EntityFrameworkCore;

namespace RSConnect.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Adicione seus DbSets aqui
    // Exemplo:
    // public DbSet<Usuario> Usuarios { get; set; }
}
