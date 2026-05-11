using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Implementation
{
    internal sealed class MoviesServiceResolver : IMoviesService
    {
        private readonly IMoviesService _moviesService;

        public MoviesServiceResolver(
            IServiceProvider serviceProvider,
            IServiceConfiguration configuration)
        {
            var serviceType = ServiceType.Micro;

            if (configuration.IsGradualMigrationEnabled)
            {
                var percent = Random.Shared.Next(0, 100);
                serviceType = percent < configuration.MoviesMigrationPercent ? ServiceType.Micro : ServiceType.Legacy;
            }

            _moviesService = serviceProvider.GetRequiredKeyedService<IMoviesService>(serviceType);
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            return await _moviesService.GetAllMoviesAsync().ConfigureAwait(false);
        }
    }
}
