using Microsoft.EntityFrameworkCore;
using SnowboardStarter.Backend.Data;
using SnowboardStarter.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Default");

// Add Services to the container
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // Allow requests from local dev front-end
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TripPlannerService>(); // Register the trip planner service

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connString));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(); // Apply CORS middleware

app.Run();
