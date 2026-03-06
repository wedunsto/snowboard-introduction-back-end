namespace SnowboardStarter.Backend.Models;

// DTO to handle data returned when a user creates a new trip plan
public class TripPlannerResponse {
    public long id { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public DateTimeOffset ArrivalDate { get; set; } = default!;
    public DateTimeOffset DepartureDate { get; set; } = default!;
    public decimal Budget { get; set; } = default!;
    public bool Completed {get; set; } = false;
}