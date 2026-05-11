using System.Collections.ObjectModel;

namespace CinemaAbyss.Proxy.Model
{
    /// <summary>
    /// Информация о фильме.
    /// </summary>
    public sealed class MovieDto
    {
        /// <summary>
        /// Идентификатор фильма.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// Описание фильма.
        /// </summary>
        public required string Description { get; init; }

        /// <summary>
        /// Список жанров фильма.
        /// </summary>
        public Collection<string> Genres { get; init; } = [];

        /// <summary>
        /// Рейтинг фильма.
        /// </summary>
        public double Rating { get; init; }
    }
}
