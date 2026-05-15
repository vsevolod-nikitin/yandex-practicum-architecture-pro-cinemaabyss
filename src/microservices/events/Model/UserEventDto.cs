using System.Text.Json.Serialization;

namespace CinemaAbyss.Events.Model
{
    /// <summary>
    /// Событие, связанное с пользователем.
    /// </summary>
    public sealed class UserEventDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [JsonPropertyName("user_id")]
        public required long UserId { get; init; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [JsonPropertyName("username")]
        public string? UserName { get; init; }

        /// <summary>
        /// Email пользователя.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; init; }

        /// <summary>
        /// Действие пользователя.
        /// </summary>
        [JsonPropertyName("action")]
        public required string Action { get; init; }

        /// <summary>
        /// Время события.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public required DateTime Timestamp { get; init; }
    }
}
