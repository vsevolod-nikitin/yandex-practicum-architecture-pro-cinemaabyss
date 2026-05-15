using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Implementation
{
    /// <summary>
    /// Функционал выбора реализации <see cref="IUsersService"/> для поддержки постепенной миграции от монолита к микросервису.
    /// </summary>
    public class UsersServiceResolver : IUsersService
    {
        private readonly IUsersService _usersService;

        public UsersServiceResolver(IServiceProvider services)
        {
            // Доступна только легаси реализация.
            _usersService = services.GetRequiredKeyedService<IUsersService>(ServiceType.Legacy);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _usersService.GetAllUsersAsync().ConfigureAwait(false);
        }
    }
}
