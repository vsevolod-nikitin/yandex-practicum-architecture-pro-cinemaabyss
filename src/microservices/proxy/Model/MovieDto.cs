using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CinemaAbyss.Proxy.Model
{
    /// <summary>
    /// Информация о фильме.
    /// </summary>
    public sealed class MovieDto
    {
        /// <summary>
        /// Уникальный идентификатор фильма.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        /// <summary>
        /// Описание фильма.
        /// </summary>
        [JsonPropertyName("description")]
        public required string Description { get; init; }

        /// <summary>
        /// Жанры фильма.
        /// </summary>
        [JsonPropertyName("genres")]
        public Collection<string> Genres { get; init; } = [];

        /// <summary>
        /// Рейтинг фильма.
        /// </summary>
        [JsonPropertyName("rating")]
        public double Rating { get; init; }
    }
}
