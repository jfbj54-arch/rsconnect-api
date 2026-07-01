using Microsoft.EntityFrameworkCore;
using RSConnect.API.Models;

namespace RSConnect.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<ProfissionalServico> ProfissionaisServicos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}
