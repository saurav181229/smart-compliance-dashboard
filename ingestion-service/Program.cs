using FluentValidation;
using FluentValidation.AspNetCore;
using ingestion_service.data;
using ingestion_service.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers().AddFluentValidation(); //binds fluent validation in the controller pipeline
builder.Services.AddValidatorsFromAssemblyContaining<EventValidator>();   //dont have to run services.addscoped<>

builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();

// DbContext registration
builder.Services.AddDbContext<EventDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EventsDb")
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

