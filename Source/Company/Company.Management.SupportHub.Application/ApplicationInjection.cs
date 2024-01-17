using Company.Management.SupportHub.Application.Services.Cryptography;
using Company.Management.SupportHub.Application.Services.Tokenization;
using Company.Management.SupportHub.Application.UseCases.EmployeeManagement;
using Company.Management.SupportHub.Application.UseCases.EmployeeManagement.Implementations;
using Company.Management.SupportHub.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Management.SupportHub.Application;

public static class ApplicationInjection
{
	public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjection(configuration);
		services.AddServices();
		services.AddUseCases();
	}

	private static void AddServices(this IServiceCollection services)
	{
		services.AddScoped<ICryptographyService, CryptographyService>();
		services.AddScoped<ITokenizationService, TokenizationService>();
	}

	private static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<ICreateEmployee, CreateEmployee>();
	}
}