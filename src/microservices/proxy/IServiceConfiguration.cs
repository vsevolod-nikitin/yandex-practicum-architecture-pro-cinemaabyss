namespace CinemaAbyss.Proxy
{
    /// <summary>
    /// Конфигурация функционала.
    /// </summary>
    public interface IServiceConfiguration
    {
        /// <summary>
        /// Порт, на котором работает прокси-сервис.
        /// </summary>
        int Port { get; }

        /// <summary>
        /// URL монолитного приложения.
        /// </summary>
        string MonolithUrl { get; }

        /// <summary>
        /// URL сервиса фильмов.
        /// </summary>
        string MoviesServiceUrl { get; }

        /// <summary>
        /// URL сервиса событий.
        /// </summary>
        string EventsServiceUrl { get; }

        /// <summary>
        /// Флаг, указывающий, включена ли постепенная миграция.
        /// </summary>
        bool IsGradualMigrationEnabled { get; }

        /// <summary>
        /// Процент трафика, направляемого на сервис фильмов при постепенной миграции.
        /// </summary>
        double MoviesMigrationPercent { get; }
    }
}
