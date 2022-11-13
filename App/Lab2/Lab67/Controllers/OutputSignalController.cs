using Lab67.Data;
using Lab67.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab67.Controllers;

public class OutputSignalController : ApiControllerBase
{
    private readonly AppDbContext _context;

    public OutputSignalController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetInputSignals()
    {
        List<OutputSignalEntity> signals = await _context.OutputSignals.OrderBy(s => s.Id).ToListAsync();
        return Ok(signals);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInputSignal(string name)
    {
        OutputSignalEntity signalEntity = (await _context.OutputSignals.AddAsync(new OutputSignalEntity()
        {
            Name = name,
        })).Entity;
        await _context.SaveChangesAsync();
        return Ok(signalEntity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInputSignal(int id)
    {
        OutputSignalEntity? signal = await _context.OutputSignals.FindAsync(id);
        if (signal == null)
        {
            return BadRequest();
        }
        _context.OutputSignals.Remove(signal);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}