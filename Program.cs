using demoApplication.Interfaces;
using demoApplication.Models;
using demoApplication.Repositories;
using demoApplication.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args); // it builds the app

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"))); // registering the database connection string
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("dbcs"),
        new MySqlServerVersion(new Version(8, 0, 36)) 
    ));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentServices>();

var app = builder.Build(); // build config saved to the app variable


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
