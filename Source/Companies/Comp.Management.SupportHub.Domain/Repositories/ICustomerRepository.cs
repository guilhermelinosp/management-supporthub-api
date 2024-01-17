using Management.SupportHub.Domain.Entities;

namespace Management.SupportHub.Domain.Repositories;

public interface ICustomerRepository
{
	Task<Customer?> FindCustomerByIdAsync(Guid customerId);
}