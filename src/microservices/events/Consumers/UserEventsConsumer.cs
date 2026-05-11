namespace CinemaAbyss.Events.Consumers
{
    /// <summary>
    /// Потребитель событий, связанных с пользователями.
    /// </summary>
    /// <param name="messageBroker">Брокер сообщений.</param>
    /// <param name="logger">Функционал логирования.</param>
    internal sealed class UserEventsConsumer(
        IMessageBroker messageBroker,
        ILogger<UserEventsConsumer> logger) : BackgroundService
    {
        /// <inheritdoc/>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var consumer = messageBroker.CreateConsumer();
            consumer.Subscribe(MessageTopics.Users);

            while (!stoppingToken.IsCancellationRequested)
            {
                var response = consumer.Consume(stoppingToken);
                if (response is null)
                {
                    continue;
                }

                logger.LogInformation("Received user event: {Event}", response.Message.Value);
            }

            consumer.Close();
            return Task.CompletedTask;
        }
    }
}
