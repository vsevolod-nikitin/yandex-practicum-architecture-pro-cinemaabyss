namespace CinemaAbyss.Proxy
{
    /// <summary>
    /// Конфигурация функционала.
    /// </summary>
    public interface IServiceConfiguration
    {
        int Port { get; }

        string MonolithUrl { get; }

        string MoviesServiceUrl { get; }

        string EventsServiceUrl { get; }

        bool IsGradualMigrationEnabled { get; }

        double MoviesMigrationPercent { get; }
    }
}
