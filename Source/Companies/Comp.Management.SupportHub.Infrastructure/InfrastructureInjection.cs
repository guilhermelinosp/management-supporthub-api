using Management.SupportHub.Domain.Repositories;
using Management.SupportHub.Infrastructure.Contexts;
using Management.SupportHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Management.SupportHub.Infrastructure;

public static class InfrastructureInjection
{
	public static void AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddContexts(configuration);
		services.AddRepositories();
		services.AddServices();
	}

	private static void AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ICompanyRepository, CompanyRepository>();
		services.AddScoped<IEmployeeRepository, EmployeeRepository>();
	}

	private static void AddServices(this IServiceCollection services)
	{
	}

	private static void AddContexts(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ManagementDbContext>(options =>
			options.UseSqlServer(configuration["ConnectionStrings:SqlServer"],
				sqlServerOptions => { sqlServerOptions.EnableRetryOnFailure(); }));
	}
}