using CinemaAbyss.Proxy.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAbyss.Proxy.Controllers
{
    /// <summary>
    /// Контроллер для получения списка фильмов через прокси-сервис.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class MoviesController(IMoviesService moviesService) : ControllerBase
    {
        /// <summary>
        /// Возвращает все фильмы.
        /// </summary>
        [HttpGet("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await moviesService.GetAllMoviesAsync().ConfigureAwait(false);
            return Ok(movies);
        }
    }
}
