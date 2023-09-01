using Persistence;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
using API.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureCors();

builder.Services.AddDbContext<IncidenciasContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
