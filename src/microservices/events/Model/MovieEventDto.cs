using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CinemaAbyss.Events.Model
{
    /// <summary>
    /// Событие, связанное с фильмом.
    /// </summary>
    public sealed class MovieEventDto
    {
        /// <summary>
        /// Идентификатор фильма.
        /// </summary>
        [JsonPropertyName("movie_id")]
        public required long MovieId { get; init; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        /// <summary>
        /// Действие с фильмом.
        /// </summary>
        [JsonPropertyName("action")]
        public required string Action { get; init; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; init; }

        /// <summary>
        /// Рейтинг.
        /// </summary>
        [JsonPropertyName("rating")]
        public double? Rating { get; init; }

        /// <summary>
        /// Жанры фильма.
        /// </summary>
        [JsonPropertyName("genres")]
        public Collection<string> Genres { get; init; } = [];

        /// <summary>
        /// Описание фильма.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }
    }
}
