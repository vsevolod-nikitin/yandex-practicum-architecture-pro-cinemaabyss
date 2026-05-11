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
    }
}
