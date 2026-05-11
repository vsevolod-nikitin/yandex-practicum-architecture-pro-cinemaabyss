using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Legacy
{
    internal sealed class LegacyMoviesService(IHttpClientFactory clientFactory) : IMoviesService
    {
        private readonly HttpClient client = clientFactory.CreateClient(nameof(LegacyMoviesService));

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var endpoint = @"/api/movies";

            return await client.GetFromJsonAsync<MovieDto[]>(endpoint) ?? [];
        }
    }
}
