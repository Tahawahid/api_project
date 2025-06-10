using api_project.api.Data;
using api_project.api.Mappings;
using api_project.api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext with SQL Server provider
builder.Services.AddDbContext<ApiProjectDBContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository interface and its implementation
builder.Services.AddScoped<IRegionRepositories, SQLRegionRepository>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperClass));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
