namespace CinemaAbyss.Events
{
    /// <summary>
    /// Доступные топики для публикации событий.
    /// </summary>
    internal static class MessageTopics
    {
        public const string Movies = "movie-events";
        public const string Users = "user-events";
        public const string Payments = "payment-events";
    }
}
