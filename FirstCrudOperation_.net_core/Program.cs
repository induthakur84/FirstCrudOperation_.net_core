using FirstCrudOperation_.net_core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

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



// app.UseAuthorization() is a middleware that enables authorization capabilities in the application. It checks if the user is authorized to access certain resources or perform specific actions based on the defined policies and roles. This middleware should be placed after authentication middleware (if any) and before any endpoint routing or controller actions that require authorization.
app.UseAuthorization();

app.MapControllers();

app.Run();

// what is the program.cs file in .net core?

// The Program.cs file in .NET Core is the entry point of the application.
// It contains the Main method, which is the starting point of the application. In this file, you typically configure and build the web application, set up services, and define the middleware pipeline. The Program.cs file is responsible for bootstrapping the application and running it.