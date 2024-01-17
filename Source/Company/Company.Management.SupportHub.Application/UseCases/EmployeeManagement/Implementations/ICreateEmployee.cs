using Company.SupportHub.Domain.DTOs.Requests.Employee;
using Company.SupportHub.Domain.DTOs.Responses;

namespace Company.SupportHub.Application.UseCases.EmployeeManagement.Implementations;

public interface ICreateEmployee
{
	Task<ResponseDefault> ExecuteAsync(EmployeeRequest request, Guid accountId);
}