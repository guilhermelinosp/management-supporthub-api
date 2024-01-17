using Company.SupportHub.Domain.DTOs.Messages;
using Company.SupportHub.Domain.DTOs.Requests.Employee;
using Company.SupportHub.Domain.Repositories;
using FluentValidation.Results;

namespace Company.SupportHub.Application.UseCases.EmployeeManagement.InternalValidation;

public class EmployeeInternalValidation()
{
	private readonly ICompanyRepository? _companyRepository;
	private readonly IEmployeeRepository? _employeeRepository;

	public EmployeeInternalValidation(
		IEmployeeRepository? employeeRepository,
		ICompanyRepository? companyRepository) : this()
	{
		_employeeRepository = employeeRepository;
		_companyRepository = companyRepository;
	}

	public async Task<ValidationResult> ValidateAsync(EmployeeRequest request, Guid accountId)
	{
		var validationResult = new ValidationResult();

		var company = await _companyRepository!.FindCompanyByAccountIdAsync(accountId);
		if (company is null)
			validationResult.Errors.Add(new ValidationFailure("COMPANY_NOT_FOUND", MessagesDefaults.COMPANY_NOT_FOUND));

		var checkCpfAsync = await _employeeRepository!.FindEmployeeByCpfAsync(request.Cpf);
		if (checkCpfAsync is not null)
			validationResult.Errors.Add(
				new ValidationFailure("CPF_ALREADY_EXISTS", MessagesDefaults.CPF_ALREADY_EXISTS));

		var checkEmailAsync = await _employeeRepository.FindAccountByEmailAsync(request.Email);
		if (checkEmailAsync is not null)
			validationResult.Errors.Add(new ValidationFailure("EMAIL_ALREADY_EXISTS",
				MessagesDefaults.EMAIL_ALREADY_EXISTS));

		return validationResult;
	}
}