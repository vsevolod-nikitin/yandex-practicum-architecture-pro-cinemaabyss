using Confluent.Kafka;

namespace CinemaAbyss.Events
{
    /// <summary>
    /// Брокер сообщений.
    /// </summary>
    internal interface IMessageBroker
    {
        /// <summary>
        /// Получить издателя для отправки событий.
        /// </summary>
        /// <returns>Издатель для отправки событий.</returns>
        IProducer<Null, string> GetProducer();
    }
}
