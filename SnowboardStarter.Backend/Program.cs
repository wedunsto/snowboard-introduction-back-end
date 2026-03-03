using Microsoft.EntityFrameworkCore;
using SnowboardStarter.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<TripPlannerService>(); // Register the trip planner service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
