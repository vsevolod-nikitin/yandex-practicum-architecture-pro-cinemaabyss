using System.Text.Json.Serialization;

namespace CinemaAbyss.Events.Model
{
    /// <summary>
    /// Информация о событии.
    /// </summary>
    public sealed class EventDto
    {
        /// <summary>
        /// Уникальный идентификатор события.
        /// </summary>
        [JsonPropertyName("id")]
        public required string EventId { get; init; }

        /// <summary>
        /// Тип события.
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; init; }

        /// <summary>
        /// Время события.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public required DateTime Timestamp { get; init; }

        /// <summary>
        /// Полезная нагрузка события.
        /// </summary>
        [JsonPropertyName("payload")]
        public object? Payload { get; init; }
    }
}
