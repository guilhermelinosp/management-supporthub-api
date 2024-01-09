using Management.SupportHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.SupportHub.Infrastructure.Contexts;

public class ManagementDbContext(DbContextOptions<ManagementDbContext> options) : DbContext(options)
{
	public DbSet<Account>? Accounts { get; set; }
}