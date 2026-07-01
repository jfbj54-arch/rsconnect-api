using RSConnect.API.Models;

namespace RSConnect.API.Services;

public interface IProfissionalService
{
    Task<IEnumerable<Profissional>> Buscar();
    Task<Profissional> Buscar(int id);
    Task<Profissional> Create(Profissional p);
    Task<bool> Update(int id, Profissional p);
    Task<bool> Delete(int id);
}
