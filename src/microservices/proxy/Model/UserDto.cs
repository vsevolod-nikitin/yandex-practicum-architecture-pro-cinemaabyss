namespace CinemaAbyss.Proxy.Model
{
    /// <summary>
    /// Информация о пользователе.
    /// </summary>
    public sealed class UserDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public required string UserName { get; init; }

        /// <summary>
        /// E-mail пользователя.
        /// </summary>
        public required string Email { get; init; }
    }
}
