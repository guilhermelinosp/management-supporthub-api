using Management.SupportHub.Domain.Entities;

namespace Management.SupportHub.Domain.Repositories;

public interface ICompanyRepository
{
	Task<Company?> FindCompanyByAccountIdAsync(Guid companyId);
}