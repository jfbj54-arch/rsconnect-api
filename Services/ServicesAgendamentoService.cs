using RSConnect.API.Models;
using RSConnect.API.Repositories;

namespace RSConnect.API.Services;

public class AgendamentoService : IAgendamentoService
{
    private readonly IRepository<Agendamento> _repo;

    public AgendamentoService(IRepository<Agendamento> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Agendamento>> GetAll()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Agendamento> GetById(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Agendamento> Criar(Agendamento ag)
    {
        await _repo.AddAsync(ag);
        await _repo.SaveAsync();
        return ag;
    }

    public async Task<bool> Atualizar(int id, Agendamento atualizado)
    {
        var ag = await _repo.GetByIdAsync(id);
        if (ag == null) return false;

        // Seu modelo só tem DataHora
        ag.DataHora = atualizado.DataHora;

        _repo.Update(ag);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> Deletar(int id)
    {
        var ag = await _repo.GetByIdAsync(id);
        if (ag == null) return false;

        _repo.Delete(ag);
        await _repo.SaveAsync();
        return true;
    }
}
