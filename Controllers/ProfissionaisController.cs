using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSConnect.API.Data;
using RSConnect.API.Models;

namespace RSConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfissionaisController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProfissionaisController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var profissionais = await _context.Profissionais
            .Include(p => p.ProfissionaisServicos)
                .ThenInclude(ps => ps.Servico)
            .ToListAsync();

        return Ok(profissionais);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var profissional = await _context.Profissionais
            .Include(p => p.ProfissionaisServicos)
                .ThenInclude(ps => ps.Servico)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (profissional == null)
            return NotFound();

        return Ok(profissional);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Profissional profissional)
    {
        _context.Profissionais.Add(profissional);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = profissional.Id }, profissional);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Profissional profissional)
    {
        if (id != profissional.Id)
            return BadRequest();

        _context.Entry(profissional).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        if (profissional == null)
            return NotFound();

        _context.Profissionais.Remove(profissional);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
