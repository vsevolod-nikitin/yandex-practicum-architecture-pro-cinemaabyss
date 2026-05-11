namespace CinemaAbyss.Events.Consumers
{
    /// <summary>
    /// Потребитель событий, связанных с платежами.
    /// </summary>
    /// <param name="messageBroker">Брокер сообщений.</param>
    /// <param name="logger">Функционал логирования.</param>
    internal sealed class PaymentEventsConsumer(
        IMessageBroker messageBroker,
        ILogger<PaymentEventsConsumer> logger) : BackgroundService
    {
        /// <inheritdoc/>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var consumer = messageBroker.CreateConsumer();
            consumer.Subscribe(MessageTopics.Payments);

            while (!stoppingToken.IsCancellationRequested)
            {
                var response = consumer.Consume(stoppingToken);
                if (response is null)
                {
                    continue;
                }

                logger.LogInformation("Received payment event: {Event}", response.Message.Value);
            }

            consumer.Close();
            return Task.CompletedTask;
        }
    }
}
