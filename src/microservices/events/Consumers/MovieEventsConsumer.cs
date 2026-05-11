namespace CinemaAbyss.Events.Consumers
{
    /// <summary>
    /// Потребитель событий, связанных с фильмами.
    /// </summary>
    /// <param name="messageBroker">Брокер сообщений.</param>
    /// <param name="logger">Функционал логирования.</param>
    internal sealed class MovieEventsConsumer(
        IMessageBroker messageBroker,
        ILogger<MovieEventsConsumer> logger) : BackgroundService
    {
        /// <inheritdoc/>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var consumer = messageBroker.CreateConsumer();
            consumer.Subscribe(MessageTopics.Movies);

            while (!stoppingToken.IsCancellationRequested)
            {
                var response = consumer.Consume(stoppingToken);
                if (response is null)
                {
                    continue;
                }

                logger.LogInformation("Received movie event: {Event}", response.Message.Value);
            }

            consumer.Close();
            return Task.CompletedTask;
        }
    }
}
