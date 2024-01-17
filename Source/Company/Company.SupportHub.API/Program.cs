using Company.Management.SupportHub.Application;
using Management.SupportHub.API.Configurations;
using Management.SupportHub.API.Filters;
using Management.SupportHub.Infrastructure.Contexts.Persistences;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

await ManagementDbContextFactory.CreateAsync(configuration["ConnectionStrings:SqlServer"]!);

services.AddApplicationInjection(configuration);
services.AddAuthenticationConfiguration(configuration);
services.AddSwaggerConfiguration();
services.AddRoutingConfiguration();
services.AddCorsConfiguration();

services.AddScoped<ExceptionFilter>();
services.AddControllers(options => { options.Filters.AddService<ExceptionFilter>(); });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	configuration.AddUserSecrets<Program>();
}
else
{
	app.UseHsts();
	app.UseExceptionHandler("/error");
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();