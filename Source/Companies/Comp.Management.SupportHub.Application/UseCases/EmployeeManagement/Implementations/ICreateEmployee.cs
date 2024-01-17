using Management.SupportHub.Domain.DTOs.Requests.Employee;
using Management.SupportHub.Domain.DTOs.Responses;

namespace Company.Management.SupportHub.Application.UseCases.EmployeeManagement.Implementations;

public interface ICreateEmployee
{
	Task<ResponseDefault> ExecuteAsync(EmployeeRequest request, Guid accountId);
}