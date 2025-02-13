using AutoMapper;
using DriversManagement.API.Data;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DriversContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("Local"),
        new MySqlServerVersion(new Version(10, 5, 9))));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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