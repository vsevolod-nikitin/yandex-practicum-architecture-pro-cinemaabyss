using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Micro
{
    /// <summary>
    /// Новая реализация <see cref="IMoviesService"/>, которая обращается к микросервису для получения информации о фильмах.
    /// </summary>
    /// <param name="clientFactory">Фабрика HTTP-клиентов.</param>
    internal sealed class MicroMoviesService(IHttpClientFactory clientFactory) : IMoviesService
    {
        private readonly HttpClient client = clientFactory.CreateClient(nameof(MicroMoviesService));

        /// <inheritdoc/>
        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var endpoint = @"/api/movies";

            return await client.GetFromJsonAsync<MovieDto[]>(endpoint) ?? [];
        }
    }
}
