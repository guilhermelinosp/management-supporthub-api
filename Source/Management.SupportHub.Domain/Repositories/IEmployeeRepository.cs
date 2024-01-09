using Management.SupportHub.Domain.Entities;

namespace Management.SupportHub.Domain.Repositories;

public interface IEmployeeRepository
{
	Task CreateEmployeeAsync(Employee employee);
	Task UpdateEmployeeAsync(Employee employee);
	Task DeleteEmployeeAsync(Employee employee);
}