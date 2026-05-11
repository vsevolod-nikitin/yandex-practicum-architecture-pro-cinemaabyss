using Confluent.Kafka;

namespace CinemaAbyss.Events.Implementation
{
    /// <summary>
    /// Реализация брокера сообщений.
    /// </summary>
    internal sealed class MessageBroker : IMessageBroker
    {
        private const string ConsumerGroupId = "cinema-abyss-events-consumers";

        private readonly ProducerBuilder<Null, string> _producerFactory;
        private readonly ConsumerBuilder<Ignore, string> _consumerFactory;

        public MessageBroker(IServiceConfiguration configuration)
        {
            // Издатели
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration.KafkaBrokers,
                EnableIdempotence = true,
            };
            _producerFactory = new ProducerBuilder<Null, string>(producerConfig);

            // Подписчики
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration.KafkaBrokers,
                GroupId = ConsumerGroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            _consumerFactory = new ConsumerBuilder<Ignore, string>(consumerConfig);
        }

        /// <inheritdoc/>
        public IProducer<Null, string> CreateProducer()
        {
            return _producerFactory.Build();
        }

        /// <inheritdoc/>
        public IConsumer<Ignore, string> CreateConsumer()
        {
            return _consumerFactory.Build();
        }
    }
}
