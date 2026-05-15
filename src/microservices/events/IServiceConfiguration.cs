namespace CinemaAbyss.Events
{
    /// <summary>
    /// Конфигурация функционала.
    /// </summary>
    internal interface IServiceConfiguration
    {
        /// <summary>
        /// Порт приема запросов.
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Адрес брокера Kafka для публикации событий.
        /// </summary>
        string KafkaBrokers { get; }
    }
}
