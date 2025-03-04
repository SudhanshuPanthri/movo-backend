using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/theaters")]
    [ApiController]
    public class TheatreController : Controller
    {
        private readonly ITheatre  _theatre;

        public TheatreController(ITheatre theatre)
        {
            _theatre = theatre;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTheatres()
        {
            try
            {
                var result = await _theatre.GetTheaters();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheatre(int id)
        {
            try
            {
                var result = await _theatre.GetTheater(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTheatersByName(string name)
        {
            try
            {
                var result = await _theatre.GetTheatersByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("location/{location}")]
        public async Task<IActionResult> GetTheatersByLocation(string location)
        {
            try
            {
                var result = await _theatre.GetTheatersByLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetTheatersByCity(string city)
        {
            try
            {
                var result = await _theatre.GetTheatersByCity(city);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTheater(Theater theater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data=await _theatre.AddTheater(theater);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateTheatre(Theater theater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data=await _theatre.UpdateTheater(theater);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpDelete("{theaterId}")]
        public async Task<IActionResult> DeleteTheatre(int theaterId)
        {
            try
            {
                var data=await _theatre.DeleteTheater(theaterId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}