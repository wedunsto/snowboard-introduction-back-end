namespace SnowboardStarter.Backend.Models;

// DTO to handle data returned when a user creates a new trip plan
public class TripPlannerResponse {
    public string Destination { get; set; } = default!;
    public DateTime ArrivalDate { get; set; } = default!;
    public DateTime DepartureDate { get; set; } = default!;
    public decimal Budget { get; set; } = default!;
    public bool Completed {get; set; } = false;
}