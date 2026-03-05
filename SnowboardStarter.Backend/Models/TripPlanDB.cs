using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnowboardStarter.Backend.Models;

[Table("trips")] // Matches the snowboardstarter SQL table name
public class Trip
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id { get; set; } // maps to BigSerial

    [Required]
    [Column("destination")]
    public string Destination { get; set; } = default!;

    [Required]
    [Column("arrival_date")]
    public DateTimeOffset ArrivalDate { get; set; }

    [Required]
    [Column("departure_date")]
    public DateTimeOffset DepartureDate { get; set; }

    [Required]
    [Column("budget")]
    public decimal Budget { get; set; }

    [Column("completed")]
    public bool Completed {get; set; } = false;
}