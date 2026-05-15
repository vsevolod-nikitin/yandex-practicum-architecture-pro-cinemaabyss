using System.Text.Json.Serialization;

namespace CinemaAbyss.Proxy.Model
{
    /// <summary>
    /// Информация о пользователе.
    /// </summary>
    public sealed class UserDto
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [JsonPropertyName("username")]
        public required string UserName { get; init; }

        /// <summary>
        /// Email пользователя.
        /// </summary>
        [JsonPropertyName("email")]
        public required string Email { get; init; }
    }
}
