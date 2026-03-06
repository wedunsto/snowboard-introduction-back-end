using Microsoft.EntityFrameworkCore;
using SnowboardStarter.Backend.Data;
using SnowboardStarter.Backend.Models; // Use the DTOs in the Models folder

namespace SnowboardStarter.Backend.Services;

// Business logicused to handle trip planning requests
public class TripPlannerService
{
    // Gain access to CRUD data on the SQL database
    private readonly AppDbContext _db;

    public TripPlannerService(AppDbContext db) {
        _db = db;
    }

    // Business logic used to handle new trip plan creation requests
    public async Task<TripPlannerResponse> createTrip(TripPlannerRequest request) {
        var newTripPlan = new Trip {
            Destination = request.destination,
            ArrivalDate = request.arrivalDate,
            DepartureDate = request.departureDate,
            Budget = request.budget
        };

        var tripResponse = new TripPlannerResponse
        {
            Destination = request.destination,
            ArrivalDate = request.arrivalDate,
            DepartureDate = request.departureDate,
            Budget = request.budget,
        };

        _db.Add(newTripPlan);
        await _db.SaveChangesAsync();

        return tripResponse;
    }

    // Business logic used to handle GET trip plan requests
    public async Task<TripPlannerResponse[]> getTrips()
    {
        var tripPlans = await _db.Trips
            .AsNoTracking()
            .ToListAsync();

        return tripPlans.Select(trip => new TripPlannerResponse
        {
            id = trip.id,
            Destination = trip.Destination,
            ArrivalDate = trip.ArrivalDate,
            DepartureDate = trip.DepartureDate,
            Budget = trip.Budget,
            Completed = trip.Completed
        }).ToArray();
    }
}