using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Micro
{
    internal sealed class MicroMoviesService(IHttpClientFactory clientFactory) : IMoviesService
    {
        private readonly HttpClient client = clientFactory.CreateClient(nameof(MicroMoviesService));

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var endpoint = @"/api/movies";

            return await client.GetFromJsonAsync<MovieDto[]>(endpoint) ?? [];
        }
    }
}
