using Microsoft.OpenApi.Models;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", false, true);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApiGateway", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGateway v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();

