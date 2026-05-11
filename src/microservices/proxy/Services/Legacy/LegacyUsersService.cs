using CinemaAbyss.Proxy.Model;

namespace CinemaAbyss.Proxy.Services.Legacy
{
    /// <summary>
    /// Легаси-реализация <see cref="IUsersService"/>, которая обращается к монолитному приложению для получения информации о пользователях.
    /// </summary>
    /// <param name="clientFactory">Фабрика HTTP-клиентов.</param>
    internal sealed class LegacyUsersService(IHttpClientFactory clientFactory) : IUsersService
    {
        private readonly HttpClient client = clientFactory.CreateClient(nameof(ServiceType.Legacy));

        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var endpoint = @"/api/users";

            return await client.GetFromJsonAsync<UserDto[]>(endpoint) ?? [];
        }
    }
}
