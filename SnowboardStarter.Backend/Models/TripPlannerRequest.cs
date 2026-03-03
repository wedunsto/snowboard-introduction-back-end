namespace SnowboardStarter.Backend.Models;

public sealed record TripPlannerRequest(
    string destination,
    DateTime arrivalDate,
    DateTime departureDate,
    decimal budget
);