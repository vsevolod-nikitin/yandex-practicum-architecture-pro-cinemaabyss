using CinemaAbyss.Events.Model;
using Confluent.Kafka;
using System.Text.Json;

namespace CinemaAbyss.Events.Services.Implementation
{
    /// <summary>
    /// Реализация издателя событий.
    /// </summary>
    /// <param name="messageBroker">Брокер сообщений.</param>
    internal sealed class EventsProducer(IMessageBroker messageBroker) : IEventsProducer
    {
        private const string MovieTopic = "movie-events";
        private const string UserTopic = "user-events";
        private const string PaymentTopic = "payment-events";

        /// <inheritdoc/>
        public async Task<EventResponseDto> RegisterMovieEventAsync(MovieEventDto eventDto)
        {
            var eventInfo = new EventDto
            {
                EventId = Guid.NewGuid().ToString("N"),
                Type = "MovieEvent",
                Timestamp = DateTime.UtcNow,
                Payload = eventDto
            };

            return await PublishEventAsync(MovieTopic, eventInfo).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<EventResponseDto> RegisterUserEventAsync(UserEventDto eventDto)
        {
            var eventInfo = new EventDto
            {
                EventId = Guid.NewGuid().ToString("N"),
                Type = "UserEvent",
                Timestamp = DateTime.UtcNow,
                Payload = eventDto
            };

            return await PublishEventAsync(UserTopic, eventInfo).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<EventResponseDto> RegisterPaymentEventAsync(PaymentEventDto eventDto)
        {
            var eventInfo = new EventDto
            {
                EventId = Guid.NewGuid().ToString("N"),
                Type = "PaymentEvent",
                Timestamp = DateTime.UtcNow,
                Payload = eventDto
            };

            return await PublishEventAsync(PaymentTopic, eventInfo).ConfigureAwait(false);
        }

        /// <summary>
        /// Опубликовать событие.
        /// </summary>
        /// <param name="topic">Топик.</param>
        /// <param name="eventInfo">Информация о событии.</param>
        /// <returns>Результат публикации события.</returns>
        private async Task<EventResponseDto> PublishEventAsync(string topic, EventDto eventInfo)
        {
            using var producer = messageBroker.GetProducer();

            var deliveryResult = await producer.ProduceAsync(
                topic,
                new Message<Null, string>
                {
                    Value = JsonSerializer.Serialize(eventInfo),

                }).ConfigureAwait(false);

            return new EventResponseDto
            {
                Status = "success",
                Partition = deliveryResult.TopicPartitionOffset.Partition.Value,
                Offset = deliveryResult.TopicPartitionOffset.Offset.Value,
                Event = eventInfo,
            };
        }
    }
}
