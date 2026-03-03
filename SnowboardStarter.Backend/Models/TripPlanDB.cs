using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnowboardStarter.Backend.Models;

[Table("trips")] // Matches the snowboardstarter SQL table name
public class Trip
{
    [Key]
    [Required]
    public string id { get; set; } = default;

    [Required]
    public string Destination { get; set; } = default!;

    [Required]
    public DateTime ArrivalDate { get; set; } = default!;

    [Required]
    public DateTime DepartureDate { get; set; } = default!;

    [Required]
    public decimal Budget { get; set; } = default!;

    public bool Completed {get; set; } = false;

    public DateTimeOffset created_at { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset updated_at { get; set; } = DateTimeOffset.UtcNow;
}