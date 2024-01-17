using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Management.SupportHub.Domain.Entities;

[Table("TB_Employee")]
public class Employee
{
	public Guid EmployeeId { get; set; } = Guid.NewGuid();
	public required string Name { get; set; }
	public required string Cpf { get; set; }
	public required string Email { get; set; }
	public bool IsDisabled { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	public DateTime DisabledAt { get; set; } = DateTime.UtcNow;
	[ForeignKey("AccountId")] public Guid AccountId { get; set; }
	[ForeignKey("CompanyId")] public Guid CompanyId { get; set; }
}