namespace CinemaAbyss.Events.Implementation
{
    /// <summary>
    /// Реализация конфигурации функционала.
    /// </summary>
    /// <param name="configuration">Внешняя конфигурация.</param>
    internal sealed class ServiceConfiguration(IConfiguration configuration) : IServiceConfiguration
    {
        /// <inheritdoc/>
        public int Port { get; } = GetValue<int>(configuration, "PORT");

        /// <inheritdoc/>
        public string KafkaBrokers { get; } = GetValue<string>(configuration, "KAFKA_BROKERS");

        /// <summary>
        /// Получить значение из конфигурации и преобразовать его к нужному типу.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="configuration">Конфигурация.</param>
        /// <param name="key">Ключ значения.</param>
        /// <returns>Значение указанного типа.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static T GetValue<T>(IConfiguration configuration, string key)
        {
            var value = configuration[key] ?? throw new InvalidOperationException($"Configuration key '{key}' is not set.");

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to convert configuration key '{key}' to type {typeof(T).Name}.", ex);
            }
        }
    }
}
