using CinemaAbyss.Proxy.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAbyss.Proxy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(IMoviesService moviesService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await moviesService.GetAllMoviesAsync().ConfigureAwait(false);
            return Ok(movies);
        }
    }
}
