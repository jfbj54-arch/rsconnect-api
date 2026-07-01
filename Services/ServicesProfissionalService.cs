using RSConnect.API.Models;
using RSConnect.API.Repositories;

namespace RSConnect.API.Services;

public class ProfissionalService : IProfissionalService
{
    private readonly IRepository<Profissional> _repo;

    public ProfissionalService(IRepository<Profissional> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Profissional>> Buscar()
        => await _repo.GetAllAsync();

    public async Task<Profissional> Buscar(int id)
        => await _repo.GetByIdAsync(id);

    public async Task<Profissional> Create(Profissional p)
    {
        await _repo.AddAsync(p);
        await _repo.SaveAsync();
        return p;
    }

    public async Task<bool> Update(int id, Profissional atualizado)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return false;

        // Seu model só tem Nome
        p.Nome = atualizado.Nome;

        _repo.Update(p);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return false;

        _repo.Delete(p);
        await _repo.SaveAsync();
        return true;
    }
}
