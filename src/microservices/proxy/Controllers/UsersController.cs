using CinemaAbyss.Proxy.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAbyss.Proxy.Controllers
{
    /// <summary>
    /// Контроллер для получения списка пользователей через прокси-сервис.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] 
    public sealed class UsersController(IUsersService usersService) : ControllerBase
    {
        /// <summary>
        /// Возвращает всех пользователей.
        /// </summary>
        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usersService.GetAllUsersAsync().ConfigureAwait(false);
            return Ok(users);
        }
    }
}
