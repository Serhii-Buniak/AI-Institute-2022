using Lab67.Data;
using Lab67.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab67.Controllers;

public class SeedController : ApiControllerBase
{
    private readonly AppDbContext _context;

    public SeedController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetSeeds()
    {
        List<Seed> seeds = await _context.Seeds
            .Include(s => s.InputSignals)
            .Include(s => s.OutputSignals)
            .ToListAsync();
        return Ok(seeds);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeed(Seed seed)
    {
        if (_context.InputSignals.Count() != seed.InputSignals.Count
        || _context.OutputSignals.Count() != seed.OutputSignals.Count)
        {
            return BadRequest();
        }

        seed = (await _context.Seeds.AddAsync(seed)).Entity;
        await _context.SaveChangesAsync();
        return Ok(seed);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSeeds()
    {
        _context.Seeds.RemoveRange(_context.Seeds);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeed(int id)
    {
        Seed? seed = await _context.Seeds.FindAsync(id);
        if (seed == null)
        {
            return BadRequest();
        }
        _context.Seeds.Remove(seed);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}