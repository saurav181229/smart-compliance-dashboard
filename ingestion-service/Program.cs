using DotNetEnv;
using FluentValidation;
using FluentValidation.AspNetCore;
using ingestion_service.data;
using ingestion_service.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
Env.Load();

builder.Services.AddControllers().AddFluentValidation(); //binds fluent validation in the controller pipeline
builder.Services.AddValidatorsFromAssemblyContaining<EventValidator>();   //dont have to run services.addscoped<>

builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEventRepository,EventRepository>();



// builder.Configuration.AddEnvironmentVariables();
Console.WriteLine(Environment.GetEnvironmentVariable("SQL_PASSWORD"));

// DbContext registration
builder.Services.AddDbContext<EventDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EventsDb").Replace("${SQL_SA_PASSWORD}",Environment.GetEnvironmentVariable("SQL_PASSWORD"))
        ?? throw new InvalidOperationException("Connection string 'EventsDb' not found.");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

     app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
                        // Generates swagger.json
   




app.Run();

