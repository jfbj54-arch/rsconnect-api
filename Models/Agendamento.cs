namespace RSConnect.API.Models;

public class Agendamento
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int ProfissionalId { get; set; }
    public int ServicoId { get; set; }
    public DateTime DataHora { get; set; }
}
