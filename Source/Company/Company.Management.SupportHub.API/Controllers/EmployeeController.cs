using System.Net;
using Company.SupportHub.API.Controllers.Abstract;
using Company.SupportHub.Application.Services.Tokenization;
using Company.SupportHub.Application.UseCases.EmployeeManagement.Implementations;
using Company.SupportHub.Domain.DTOs.Messages;
using Company.SupportHub.Domain.DTOs.Requests.Employee;
using Company.SupportHub.Domain.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Company.SupportHub.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[ProducesResponseType<BaseActionResult<ResponseException>>(StatusCodes.Status400BadRequest)]
public class EmployeeController(ICreateEmployee createEmployee, ITokenizationService tokenization) : Controller
{
	[HttpPost]
	[ProducesResponseType<BaseActionResult<ResponseDefault>>(StatusCodes.Status200OK)]
	public async Task<BaseActionResult<ResponseDefault>> CreateEmployeeAsync([FromBody] EmployeeRequest request)
	{
		var token = Request.Headers.Authorization.ToString().Split(" ")[1];
		if (string.IsNullOrWhiteSpace(token))
			throw new UnauthorizedAccessException(MessageExceptions.TOKEN_NOT_PROVIDED);

		var accountId = tokenization.ValidateToken(token);
		if (accountId == Guid.Empty)
			throw new UnauthorizedAccessException(MessageExceptions.TOKEN_NOT_PROVIDED);

		var response = await createEmployee.ExecuteAsync(request, accountId);
		return new BaseActionResult<ResponseDefault>(HttpStatusCode.OK, response);
	}
}