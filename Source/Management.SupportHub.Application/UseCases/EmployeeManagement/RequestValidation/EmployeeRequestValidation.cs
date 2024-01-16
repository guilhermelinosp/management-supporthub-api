using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using Management.SupportHub.Domain.DTOs.Messages;
using Management.SupportHub.Domain.DTOs.Requests.Employee;

namespace Company.Management.SupportHub.Application.UseCases.EmployeeManagement.RequestValidation;

public partial class EmployeeRequestValidation : AbstractValidator<EmployeeRequest>
{
	public EmployeeRequestValidation()
	{
		RuleFor(e => e.Email)
			.NotEmpty()
			.WithMessage(MessagesDefaults.EMAIL_NOT_INFORMED)
			.EmailAddress()
			.WithMessage(MessagesDefaults.EMAIL_NOT_VALID);


		RuleFor(e => e.Name)
			.NotEmpty()
			.WithMessage(MessagesDefaults.NAME_NOT_INFORMED)
			.Custom((name, validator) =>
			{
				if (!RegexName().IsMatch(name))
					validator.AddFailure(new ValidationFailure(nameof(EmployeeRequest.Name),
						MessagesDefaults.NAME_NOT_VALID));
			});

		RuleFor(e => e.Cpf)
			.NotEmpty()
			.WithMessage(MessagesDefaults.CPF_NOT_INFORMED)
			.Custom((cnpj, validator) =>
			{
				if (!RegexCpf().IsMatch(cnpj))
					validator.AddFailure(new ValidationFailure(nameof(EmployeeRequest.Cpf),
						MessagesDefaults.CPF_NOT_VALID));
			});
	}

	[GeneratedRegex(@"^\d{11}$")]
	private static partial Regex RegexCpf();


	[GeneratedRegex(@"^[a-zA-ZÀ-ú\s]+$")]
	private static partial Regex RegexName();
}