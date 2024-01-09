namespace Management.SupportHub.Domain.DTOs.Requests.Employee;

public class RequestEmployee
{
	public required string Name { get; set; }
	public required string Email { get; set; }
	public required string Cpf { get; set; }
}