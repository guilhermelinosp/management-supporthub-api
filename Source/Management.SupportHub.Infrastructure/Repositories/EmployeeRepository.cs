using Management.SupportHub.Domain.Entities;
using Management.SupportHub.Domain.Repositories;

namespace Management.SupportHub.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
	public async Task CreateEmployeeAsync(Employee employee)
	{
	}

	public async Task UpdateEmployeeAsync(Employee employee)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteEmployeeAsync(Employee employee)
	{
		throw new NotImplementedException();
	}
}