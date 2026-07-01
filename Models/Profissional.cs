using System.Collections.Generic;

namespace RSConnect.API.Models;

public class Profissional
{
    public int Id { get; set; }
    public string Nome { get; set; }

    // Relação com ProfissionalServico
    public ICollection<ProfissionalServico>? ProfissionaisServicos { get; set; }
}
