using Company.SupportHub.Domain.Entities;

namespace Company.SupportHub.Domain.Repositories;

public interface ICustomerRepository
{
	Task<Customer?> FindCustomerByIdAsync(Guid customerId);
}