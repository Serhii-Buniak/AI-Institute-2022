using Lab67.Data;
using Lab67.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab67.Controllers;

public class InputSignalController : ApiControllerBase
{
    private readonly AppDbContext _context;

    public InputSignalController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetInputSignals()
    {
        List<InputSignalEntity> signals = await _context.InputSignals.OrderBy(s => s.Id).ToListAsync();
        return Ok(signals);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInputSignal(string name)
    {
        InputSignalEntity InputSignalEntity = (await _context.InputSignals.AddAsync(new InputSignalEntity()
        {
            Name = name,
        })).Entity;
        await _context.SaveChangesAsync();
        return Ok(InputSignalEntity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInputSignal(int id)
    {
        InputSignalEntity? inputSignal = await _context.InputSignals.FindAsync(id);
        if (inputSignal == null)
        {
            return BadRequest();
        }
        _context.InputSignals.Remove(inputSignal);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}