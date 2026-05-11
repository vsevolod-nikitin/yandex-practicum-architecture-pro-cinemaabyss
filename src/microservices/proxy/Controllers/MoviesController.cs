using CinemaAbyss.Proxy.Model;
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

        /// <summary>
        /// Получить информацию о фильме по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор фильма.</param>
        /// <returns>Информация о фильме.</returns>
        [HttpGet("id={id}")]
        public async Task<IActionResult> GetMovieById(long id)
        {
            var movie = await moviesService.GetMovieByIdAsync(id).ConfigureAwait(false);
            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Добавить информацию о фильме.
        /// </summary>
        /// <param name="movie">Информация о фильме.</param>
        /// <returns>Созданный фильм.</returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDto movie)
        {
            var createdMovie = await moviesService.CreateMovieAsync(movie).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }
    }
}
