using CinemaAbyss.Events.Model;

namespace CinemaAbyss.Events.Services.Implementation
{
    /// <summary>
    /// Реализация издателя событий.
    /// </summary>
    internal sealed class EventsProducer : IEventsProducer
    {
        /// <inheritdoc/>
        public Task<EventResponseDto> RegisterAsync(MovieEventDto eventDto)
        {
            return Task.FromResult(GetTestResponse());
        }

        /// <inheritdoc/>
        public Task<EventResponseDto> RegisterAsync(UserEventDto eventDto)
        {
            return Task.FromResult(GetTestResponse());
        }

        /// <inheritdoc/>
        public Task<EventResponseDto> RegisterAsync(PaymentEventDto eventDto)
        {
            return Task.FromResult(GetTestResponse());
        }

        private static EventResponseDto GetTestResponse()
        {
            var response = new EventResponseDto
            {
                Status = "success",
                Partition = 0,
                Offset = 0,
                Event = new EventDto
                {
                    EventId = "eventId",
                    Type = "TestEvent",
                    Timestamp = DateTime.UtcNow,
                    Payload = new { Message = "This is a test event." }
                }
            };

            return response;
        }
    }
}
