using System.Text.Json.Serialization;

namespace CinemaAbyss.Events.Model
{
    /// <summary>
    /// Ответ при регистрации события.
    /// </summary>
    public sealed class EventResponseDto
    {
        /// <summary>
        /// Статус операции.
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>
        /// Партиция Kafka.
        /// </summary>
        [JsonPropertyName("partition")]
        public required long Partition { get; init; }

        /// <summary>
        /// Смещение в партиции Kafka.
        /// </summary>
        [JsonPropertyName("offset")]
        public required long Offset { get; init; }
        
        /// <summary>
        /// Событие.
        /// </summary>
        [JsonPropertyName("event")]
        public required EventDto Event { get; init; }
    }
}
