using Management.SupportHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.SupportHub.Infrastructure.Contexts;

public class ManagementDbContext(DbContextOptions<ManagementDbContext> options) : DbContext(options)
{
	public DbSet<Account>? Accounts { get; set; }
	public DbSet<Employee>? Employees { get; set; }

	public DbSet<Customer>? Customers { get; set; }
	public DbSet<Company>? Companies { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementDbContext).Assembly);
	}
}