using Company.Management.SupportHub.Domain.Entities;

namespace Company.Management.SupportHub.Domain.Repositories;

public interface ICustomerRepository
{
	Task<Customer?> FindCustomerByIdAsync(Guid customerId);
}