using Company.Management.SupportHub.Application.Services.Cryptography;
using Company.Management.SupportHub.Application.UseCases.EmployeeManagement.Implementations;
using Company.Management.SupportHub.Application.UseCases.EmployeeManagement.InternalValidation;
using Company.Management.SupportHub.Application.UseCases.EmployeeManagement.RequestValidation;
using Management.SupportHub.Domain.DTOs.Requests.Employee;
using Management.SupportHub.Domain.DTOs.Responses;
using Management.SupportHub.Domain.Entities;
using Management.SupportHub.Domain.Exceptions;
using Management.SupportHub.Domain.Repositories;

namespace Company.Management.SupportHub.Application.UseCases.EmployeeManagement;

public class CreateEmployee(
	ICryptographyService cryptography,
	ICompanyRepository companyRepository,
	IEmployeeRepository employeeRepository) : ICreateEmployee
{
	public async Task<ResponseDefault> ExecuteAsync(EmployeeRequest request, Guid accountId)
	{
		try
		{
			var requestValidation = await new EmployeeRequestValidation().ValidateAsync(request);
			if (!requestValidation.IsValid)
				throw new DefaultException(requestValidation.Errors.Select(er => er.ErrorMessage).ToList());

			var internalValidation =
				await new EmployeeInternalValidation(employeeRepository, companyRepository).ValidateAsync(request,
					accountId);
			if (!internalValidation.IsValid)
				throw new DefaultException(internalValidation.Errors.Select(er => er.ErrorMessage).ToList());

			var account = new Account
			{
				Identity = request.Cpf,
				Email = request.Email,
				Password = cryptography.EncryptPassword("Mudar@123")
			};

			var employee = new Employee
			{
				Cpf = request.Cpf,
				Name = request.Name,
				Email = request.Email,
				CompanyId = (await companyRepository.FindCompanyByAccountIdAsync(accountId))!.CompanyId,
				AccountId = account.AccountId
			};

			await employeeRepository.CreateEmployeeAsync(employee);

			await employeeRepository.CreateAccountAsync(account);

			return new ResponseDefault
			{
				Message = "Funcionário criado com sucesso!"
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}