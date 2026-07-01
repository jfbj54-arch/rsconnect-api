namespace RSConnect.API.Models;

public class ProfissionalServico
{
    public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public int ServicoId { get; set; }

    // Navegação
    public Servico? Servico { get; set; }
}
