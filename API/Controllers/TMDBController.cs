using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly ITMDBService _tmdbService;

        public TMDBController(ITMDBService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        // Get Now Playing Movies
        [HttpGet("now-playing")]
        public async Task<IActionResult> GetNowPlaying([FromQuery] int page = 1)
        {
            try
            {
                var movies = await _tmdbService.GetNowPlaying(page);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get Popular Movies
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopular([FromQuery] int page = 1)
        {
            try
            {
                var movies = await _tmdbService.GetPopular(page);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get Top Rated Movies
        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated([FromQuery] int page = 1)
        {
            try
            {
                var movies = await _tmdbService.GetTopRated(page);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get Movie Details
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            try
            {
                var movieDetails = await _tmdbService.GetDetail(id);
                return Ok(movieDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        //Get images related to movie
        [HttpGet("images/{id}")]
        public async Task<IActionResult> GetImages(int id)
        {
            try
            {
                var imageDetails = await _tmdbService.GetImages(id);
                return Ok(imageDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
