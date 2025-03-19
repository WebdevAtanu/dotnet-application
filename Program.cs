using demoApplication.Interfaces;
using demoApplication.Models;
using demoApplication.Repositories;
using demoApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // it builds the app

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"))); // registering the database connection string

builder.Services.AddScoped<IStudentInterface, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentServices>();

var app = builder.Build(); // build config saved to the app variable

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("This will show first and then next function will call");
//    await next(context);
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("This will show second and then next function will call");
//    await next(context);
//});

app.MapGet("/", () => "hello world"); // this response will show on homepage

//// Configure the HTTP request pipeline.
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
