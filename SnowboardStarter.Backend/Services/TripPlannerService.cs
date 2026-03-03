using SnowboardStarter.Backend.Models;

namespace SnowboardStarter.Backend.Services;

public class TripPlannerService
{
    // Business logic used to handle new trip plan creation requests
    public async Task<TripPlannerResponse> createTrip(TripPlannerRequest request) {
        var newTripPlan = new TripPlannerResponse {
            Destination = request.destination,
            ArrivalDate = request.arrivalDate,
            DepartureDate = request.departureDate,
            Budget = request.budget,
            Completed = false,
        };

        return newTripPlan;
    }
}