using Company.Management.SupportHub.Infrastructure.Contexts;
using Company.SupportHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.Management.SupportHub.Infrastructure.Repositories;

public class CompanyRepository(ManagementDbContext context) : ICompanyRepository
{
	public async Task<Company.SupportHub.Domain.Entities.Company?> FindCompanyByAccountIdAsync(Guid accountId)
	{
		return await context.Companies!.AsNoTracking().FirstOrDefaultAsync(company => company.AccountId == accountId)!;
	}
}