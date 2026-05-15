using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Legacy
{
    /// <summary>
    /// Легаси-реализация <see cref="IMoviesService"/>, которая обращается к монолитному приложению для получения информации о фильмах.
    /// </summary>
    /// <param name="clientFactory">Фабрика HTTP-клиентов.</param>
    internal sealed class LegacyMoviesService(IHttpClientFactory clientFactory) : IMoviesService
    {
        private readonly HttpClient client = clientFactory.CreateClient(nameof(ServiceType.Legacy));

        /// <inheritdoc/>
        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var endpoint = @"/api/movies";

            return await client.GetFromJsonAsync<MovieDto[]>(endpoint) ?? [];
        }

        /// <inheritdoc/>
        public async Task<MovieDto?> GetMovieByIdAsync(long id)
        {
            var endpoint = $@"/api/movies?id={id}";

            try
            {
                return await client.GetFromJsonAsync<MovieDto>(endpoint);
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<MovieDto> CreateMovieAsync(MovieDto movie)
        {
            var endpoint = @"/api/movies";

            var response = await client.PostAsJsonAsync(endpoint, movie).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MovieDto>().ConfigureAwait(false) ?? throw new InvalidOperationException("Ответ не содержит данных о фильме.");
        }
    }
}
