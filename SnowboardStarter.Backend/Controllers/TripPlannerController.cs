using Microsoft.AspNetCore.Mvc;
using SnowboardStarter.Backend.Models;
using SnowboardStarter.Backend.Services;

namespace SnowboardStarter.Backend.Controllers;

// Controller used to handle requests to create new trip plans
[ApiController]
[Route("trips")]
public class TripPlannerController: ControllerBase {
    private readonly TripPlannerService _tripPlannerService;

    public TripPlannerController(TripPlannerService tripPlannerService)
    {
        _tripPlannerService = tripPlannerService;
    }

    [HttpPost("createTrip")]
    public async Task<IActionResult> CreateTrip([FromBody] TripPlannerRequest request) {
        try
        {
            var newTripPlan = await _tripPlannerService.createTrip(request);
            return Created("", newTripPlan); // 201 for successful trip plan creation
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "An unexpected error occurred"});
        }
    }
}