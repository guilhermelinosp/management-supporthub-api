using Company.Management.SupportHub.API.Configurations;
using Company.Management.SupportHub.API.Filters;
using Company.Management.SupportHub.Application;
using Company.Management.SupportHub.Infrastructure.Contexts.Persistences;

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
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseExceptionHandler("/error");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();