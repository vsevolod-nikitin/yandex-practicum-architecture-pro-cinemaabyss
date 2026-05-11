using System.Collections.ObjectModel;

namespace CinemaAbyss.Proxy.Model
{
    public sealed class MovieDto
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public Collection<string> Genres { get; init; } = [];
        public double Rating { get; init; }
    }
}
