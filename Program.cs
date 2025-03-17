var builder = WebApplication.CreateBuilder(args); // it builds the app

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
