using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Implementation
{
    /// <summary>
    /// Функционал выбора реализации <see cref="IMoviesService"/> для поддержки постепенной миграции от монолита к микросервису.
    /// </summary>
    internal sealed class MoviesServiceResolver : IMoviesService
    {
        private readonly IMoviesService _moviesService;

        public MoviesServiceResolver(
            IServiceProvider services,
            IServiceConfiguration configuration)
        {
            // По умолчанию используем микросервисную реализацию
            var serviceType = ServiceType.Micro;

            // Если включена постепенная миграция, выбираем реализацию случайным образом в соответствии с заданным процентом
            if (configuration.IsGradualMigrationEnabled)
            {
                var percent = Random.Shared.Next(0, 100);
                serviceType = percent < configuration.MoviesMigrationPercent ? ServiceType.Micro : ServiceType.Legacy;
            }

            // Получаем нужную реализацию
            _moviesService = services.GetRequiredKeyedService<IMoviesService>(serviceType);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            return await _moviesService.GetAllMoviesAsync().ConfigureAwait(false);
        }
    }
}
