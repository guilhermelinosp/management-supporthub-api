using Management.SupportHub.Domain.Entities;
using Management.SupportHub.Domain.Repositories;
using Management.SupportHub.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Management.SupportHub.Infrastructure.Repositories;

public class EmployeeRepository(ManagementDbContext context) : IEmployeeRepository
{
	public async Task CreateEmployeeAsync(Employee employee)
	{
		await context.Employees!.AddAsync(employee);
		await SaveChangesAsync();
	}

	public async Task CreateAccountAsync(Account account)
	{
		await context.Accounts!.AddAsync(account);
		await SaveChangesAsync();
	}

	public async Task<Account?> FindAccountByEmailAsync(string email)
	{
		return await context.Accounts!.AsNoTracking()
			.FirstOrDefaultAsync(employee => employee.Email == email);
	}

	public async Task<Employee?> FindEmployeeByCpfAsync(string cpf)
	{
		return await context.Employees!.AsNoTracking()
			.FirstOrDefaultAsync(employee => employee.Cpf == cpf)!;
	}

	public async Task<Employee?> FindEmployeeByIdAsync(Guid employeeId)
	{
		return await context.Employees!.AsNoTracking()
			.FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId)!;
	}


	private async Task SaveChangesAsync()
	{
		await context.SaveChangesAsync();
	}
}