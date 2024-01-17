namespace Company.Management.SupportHub.Domain.Repositories;

public interface ICompanyRepository
{
	Task<Entities.Company?> FindCompanyByAccountIdAsync(Guid companyId);
}