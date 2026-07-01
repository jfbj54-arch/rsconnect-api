using RSConnect.API.Models;

namespace RSConnect.API.Services;

public interface IAgendamentoService
{
    Task<IEnumerable<Agendamento>> GetAll();
    Task<Agendamento> GetById(int id);
    Task<Agendamento> Criar(Agendamento ag);
    Task<bool> Atualizar(int id, Agendamento atualizado);
    Task<bool> Deletar(int id);
}
