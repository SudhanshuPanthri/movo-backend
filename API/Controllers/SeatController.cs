using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/seats")]
[ApiController]
public class SeatController : Controller
{
    private readonly ISeat _seat;

    public SeatController(ISeat seat)
    {
        _seat = seat;
    }

    [HttpGet]
    public async Task<IActionResult> GetSeats()
    {
        try
        {
            var result = await _seat.GetSeats();
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSeats(int id)
    {
        try
        {
            var result = await _seat.GetSeat(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    
    [HttpGet("theatre/{theatreId}")]
    public async Task<IActionResult> GetSeatsByTheatre(int theatreId)
    {
        try
        {
            var result = await _seat.GetSeatsByTheatre(theatreId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    
}