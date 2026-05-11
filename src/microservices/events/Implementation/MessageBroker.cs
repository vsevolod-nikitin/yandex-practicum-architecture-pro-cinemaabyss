using Confluent.Kafka;

namespace CinemaAbyss.Events.Implementation
{
    /// <summary>
    /// Реализация брокера сообщений.
    /// </summary>
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly ProducerBuilder<Null, string> _producerFactory;

        public MessageBroker(IServiceConfiguration configuration)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration.KafkaBrokers
            };

            _producerFactory = new ProducerBuilder<Null, string>(producerConfig);
        }

        /// <inheritdoc/>
        public IProducer<Null, string> GetProducer()
        {
            return _producerFactory.Build();
        }
    }
}
