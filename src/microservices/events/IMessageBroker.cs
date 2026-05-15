using Confluent.Kafka;

namespace CinemaAbyss.Events
{
    /// <summary>
    /// Брокер сообщений.
    /// </summary>
    internal interface IMessageBroker
    {
        /// <summary>
        /// Создать нового издателя для отправки событий.
        /// </summary>
        /// <returns>Издатель для отправки событий.</returns>
        IProducer<Null, string> CreateProducer();
        
        /// <summary>
        /// Создать нового потребителя для получения событий.
        /// </summary>
        /// <returns>Потребитель для получения событий.</returns>
        IConsumer<Ignore, string> CreateConsumer();
    }
}
