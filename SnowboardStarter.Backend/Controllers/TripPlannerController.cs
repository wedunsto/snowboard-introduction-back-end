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
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message }); // 400 Bad Request error
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message});
        }
    }

    [HttpGet("getTrips")]
    public async Task<IActionResult> GetTrips()
    {
        try
        {
            var tripPlans = await _tripPlannerService.getTrips();
            return Ok(tripPlans);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message }); // 400 Bad Request error
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message});
        }
    }
}