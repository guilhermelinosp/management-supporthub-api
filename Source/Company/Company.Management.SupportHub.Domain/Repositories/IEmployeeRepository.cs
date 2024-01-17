using Company.SupportHub.Domain.Entities;

namespace Company.SupportHub.Domain.Repositories;

public interface IEmployeeRepository
{
	Task CreateEmployeeAsync(Employee employee);
	Task CreateAccountAsync(Account account);
	Task<Account?> FindAccountByEmailAsync(string email);
	Task<Employee?> FindEmployeeByCpfAsync(string cpf);
	Task<Employee?> FindEmployeeByIdAsync(Guid employeeId);
}