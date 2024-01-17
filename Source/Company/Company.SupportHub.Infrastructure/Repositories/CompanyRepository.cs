using Management.SupportHub.Domain.Entities;
using Management.SupportHub.Domain.Repositories;
using Management.SupportHub.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Management.SupportHub.Infrastructure.Repositories;

public class CompanyRepository(ManagementDbContext context) : ICompanyRepository
{
	public async Task<Company?> FindCompanyByAccountIdAsync(Guid accountId)
	{
		return await context.Companies!.AsNoTracking().FirstOrDefaultAsync(company => company.AccountId == accountId)!;
	}
}