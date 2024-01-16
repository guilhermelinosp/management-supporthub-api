using System.ComponentModel.DataAnnotations;
using Management.SupportHub.Domain.DTOs.Messages;
using Management.SupportHub.Domain.DTOs.Requests.Employee;
using Management.SupportHub.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Company.Management.SupportHub.Application.UseCases.EmployeeManagement.InternalValidation;

public class EmployeeInternalValidation()
{
	private readonly IEmployeeRepository employeeRepository;
	private readonly ICompanyRepository companyRepository;

	public EmployeeInternalValidation(
		IEmployeeRepository employeeRepository,
		ICompanyRepository companyRepository)
	{
		this.employeeRepository = employeeRepository;
		this.companyRepository = companyRepository;
	}

	public async Task<ValidationResult> ValidateAsync(EmployeeRequest request, Guid accountId)
	{
		var validationResult = new ValidationResult("EmployeeInternalValidation");

		var company = await companyRepository.FindCompanyByAccountIdAsync(accountId);
		if (company is null)
			validationResult.Errors.Add(new ValidationFailure("COMPANY_NOT_FOUND", MessagesDefaults.COMPANY_NOT_FOUND));

		var checkCpfAsync = await employeeRepository.FindEmployeeByCpfAsync(request.Cpf);
		if (checkCpfAsync is not null)
			validationResult.Errors.Add(
				new ValidationFailure("CPF_ALREADY_EXISTS", MessagesDefaults.CPF_ALREADY_EXISTS));

		var checkEmailAsync = await employeeRepository.FindAccountByEmailAsync(request.Email);
		if (checkEmailAsync is not null)
			validationResult.Errors.Add(new ValidationFailure("EMAIL_ALREADY_EXISTS",
				MessagesDefaults.EMAIL_ALREADY_EXISTS));

		return validationResult;
	}
}