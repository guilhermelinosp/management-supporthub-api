using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.SupportHub.Domain.Entities;

[Table("TB_Customer")]
public class Customer
{
	[Key] public Guid EmployeeId { get; set; } = Guid.NewGuid();
	public required string Name { get; set; }
	public required string Cnpj { get; set; }
	public int License { get; set; } = 0;
	public bool IsDisabled { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	public DateTime DisabledAt { get; set; } = DateTime.UtcNow;
	[ForeignKey("AccountId")] public Guid AccountId { get; set; }
	[ForeignKey("CompanyId")] public Guid CompanyId { get; set; }
}