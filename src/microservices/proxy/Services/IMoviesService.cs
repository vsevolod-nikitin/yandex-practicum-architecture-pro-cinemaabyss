using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services
{
    /// <summary>
    /// Сервис для получения информации о фильмах.
    /// </summary>
    public interface IMoviesService
    {
        /// <summary>
        /// Получить информацию о всех фильмах.
        /// </summary>
        /// <returns>Информация о фильмах.</returns>
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();

        /// <summary>
        /// Получить информацию о фильме по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор фильма.</param>
        /// <returns>Информация о фильме или null, если фильм не найден.</returns>
        Task<MovieDto?> GetMovieByIdAsync(long id);
        
        /// <summary>
        /// Создать новый фильм.
        /// </summary>
        /// <param name="movie">Информация о фильме.</param>
        /// <returns>Созданный фильм.</returns>
        Task<MovieDto> CreateMovieAsync(MovieDto movie);
    }
}
