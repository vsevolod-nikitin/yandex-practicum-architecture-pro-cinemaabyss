using CinemaAbyss.Events.Model;
using CinemaAbyss.Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAbyss.Events.Controllers
{
    /// <summary>
    /// Контроллер для обработки событий.
    /// </summary>
    /// <param name="eventsProducer">Издатель событий.</param>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class EventsController(IEventsProducer eventsProducer) : ControllerBase
    {
        /// <summary>
        /// Зарегистрировать новое событие, связанное с фильмом.
        /// </summary>
        /// <param name="eventDto">Данные события.</param>
        /// <returns>Результат.</returns>
        [HttpPost("movie")]
        public async Task<IActionResult> RegisterMovieEvent([FromBody] MovieEventDto eventDto)
        {
            var result = await eventsProducer.RegisterAsync(eventDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Зарегистрировать новое событие, связанное с пользователем.
        /// </summary>
        /// <param name="eventDto">Данные события.</param>
        /// <returns>Результат.</returns>
        [HttpPost("user")]
        public async Task<IActionResult> RegisterUserEvent([FromBody] UserEventDto eventDto)
        {
            var result = await eventsProducer.RegisterAsync(eventDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Зарегистрировать новое событие, связанное с платежом.
        /// </summary>
        /// <param name="eventDto">Данные события.</param>
        /// <returns>Результат.</returns>
        [HttpPost("payment")]
        public async Task<IActionResult> RegisterPaymentEvent([FromBody] PaymentEventDto eventDto)
        {
            var result = await eventsProducer.RegisterAsync(eventDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
