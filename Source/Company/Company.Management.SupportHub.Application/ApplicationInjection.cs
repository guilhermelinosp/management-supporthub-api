using Company.Management.SupportHub.Infrastructure;
using Company.SupportHub.Application.Services.Cryptography;
using Company.SupportHub.Application.Services.Tokenization;
using Company.SupportHub.Application.UseCases.EmployeeManagement;
using Company.SupportHub.Application.UseCases.EmployeeManagement.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.SupportHub.Application;

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