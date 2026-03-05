using Microsoft.EntityFrameworkCore;
using SnowboardStarter.Backend.Models;

namespace SnowboardStarter.Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Allows CRUD queries for the Trip data
    public DbSet<Trip> Trips => Set<Trip>();

    // Configure the model from th entity types exposed in DbSet<Trip> properties
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var e = modelBuilder.Entity<Trip>();

        e.ToTable("trips");
        e.HasKey(t => t.id);

        e.Property(t => t.Destination);
        e.Property(t => t.ArrivalDate);
        e.Property(t => t.DepartureDate);
        e.Property(t => t.Budget);
        e.Property(t => t.Completed);
    }
}