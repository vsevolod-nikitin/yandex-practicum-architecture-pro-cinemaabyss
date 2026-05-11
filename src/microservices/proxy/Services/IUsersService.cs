using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services
{
    /// <summary>
    /// Сервис для получения информации о пользователях.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns>Набор пользователей.</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
