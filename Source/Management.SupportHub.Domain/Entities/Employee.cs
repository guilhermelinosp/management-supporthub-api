using System.ComponentModel.DataAnnotations.Schema;

namespace Management.SupportHub.Domain.Entities;

[Table("TB_Employee")]
public class Employee
{
	public Guid EmployeeId { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	[ForeignKey("AccountId")] public Guid AccountId { get; set; }
}