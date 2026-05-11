using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    }
}
