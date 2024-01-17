#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Management.SupportHub.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateTables : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			"TB_Customer",
			table => new
			{
				EmployeeId = table.Column<Guid>("uniqueidentifier", nullable: false),
				Name = table.Column<string>("nvarchar(max)", nullable: false),
				Cnpj = table.Column<string>("nvarchar(max)", nullable: false),
				License = table.Column<int>("int", nullable: false),
				IsDisabled = table.Column<bool>("bit", nullable: false),
				CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
				UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
				DisabledAt = table.Column<DateTime>("datetime2", nullable: false),
				AccountId = table.Column<Guid>("uniqueidentifier", nullable: false),
				CompanyId = table.Column<Guid>("uniqueidentifier", nullable: false)
			},
			constraints: table => { table.PrimaryKey("PK_TB_Customer", x => x.EmployeeId); });

		migrationBuilder.CreateTable(
			"TB_Employee",
			table => new
			{
				EmployeeId = table.Column<Guid>("uniqueidentifier", nullable: false),
				Name = table.Column<string>("nvarchar(max)", nullable: false),
				Cpf = table.Column<string>("nvarchar(max)", nullable: false),
				Email = table.Column<string>("nvarchar(max)", nullable: false),
				IsDisabled = table.Column<bool>("bit", nullable: false),
				CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
				UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
				DisabledAt = table.Column<DateTime>("datetime2", nullable: false),
				AccountId = table.Column<Guid>("uniqueidentifier", nullable: false),
				CompanyId = table.Column<Guid>("uniqueidentifier", nullable: false)
			},
			constraints: table => { table.PrimaryKey("PK_TB_Employee", x => x.EmployeeId); });
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			"TB_Account");

		migrationBuilder.DropTable(
			"TB_Company");

		migrationBuilder.DropTable(
			"TB_Customer");

		migrationBuilder.DropTable(
			"TB_Employee");
	}
}