namespace SnowboardStarter.Backend.Models;

public sealed record TripPlannerRequest(
    string destination,
    DateTimeOffset arrivalDate,
    DateTimeOffset departureDate,
    decimal budget
);