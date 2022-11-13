using Lab67.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab67.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<InputSignalEntity> InputSignals => Set<InputSignalEntity>();
	public DbSet<OutputSignalEntity> OutputSignals => Set<OutputSignalEntity>();
	public DbSet<Seed> Seeds => Set<Seed>();
}
