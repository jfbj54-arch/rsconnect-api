using Microsoft.AspNetCore.Mvc;
using RSConnect.API.Models;
using RSConnect.API.Services;

namespace RSConnect.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _service;

        public AgendamentosController(IAgendamentoService service)
        {
            _service = service;
        }

        // GET: api/Agendamentos
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        // GET: api/Agendamentos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ag = await _service.GetById(id);
            return ag == null ? NotFound() : Ok(ag);
        }

        // POST: api/Agendamentos
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Agendamento ag)
        {
            var criado = await _service.Criar(ag);
            return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
        }

        // PUT: api/Agendamentos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Agendamento atualizado)
        {
            var ok = await _service.Atualizar(id, atualizado);
            return ok ? Ok() : NotFound();
        }

        // DELETE: api/Agendamentos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var ok = await _service.Deletar(id);
            return ok ? Ok() : NotFound();
        }
    }
}
