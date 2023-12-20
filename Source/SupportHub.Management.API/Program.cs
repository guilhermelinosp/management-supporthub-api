var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
	app.UseHttpsRedirection();
}

app.Run();