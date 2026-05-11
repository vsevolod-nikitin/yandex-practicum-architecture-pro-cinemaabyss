namespace CinemaAbyss.Proxy.Implementation
{
    internal sealed class ServiceConfiguration(IConfiguration configuration) : IServiceConfiguration
    {
        public int Port { get; } = GetValue<int>(configuration, "PORT");

        public string MonolithUrl { get; } = GetValue<string>(configuration, "MONOLITH_URL");

        public string MoviesServiceUrl { get; } = GetValue<string>(configuration, "MOVIES_SERVICE_URL");

        public string EventsServiceUrl { get; } = GetValue<string>(configuration, "EVENTS_SERVICE_URL");

        public bool IsGradualMigrationEnabled { get; } = GetValue<bool>(configuration, "GRADUAL_MIGRATION");

        public double MoviesMigrationPercent { get; } = GetValue<double>(configuration, "MOVIES_MIGRATION_PERCENT");

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
