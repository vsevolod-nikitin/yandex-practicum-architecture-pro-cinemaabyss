using CinemaAbyss.Events.Model;

namespace CinemaAbyss.Events.Services
{
    /// <summary>
    /// Издатель событий.
    /// </summary>
    public interface IEventsProducer
    {
        /// <summary>
        /// Зарегистрировать событие.
        /// </summary>
        /// <param name="eventDto">Информация о событии.</param>
        /// <returns>Результат.</returns>
        Task<EventResponseDto> RegisterAsync(MovieEventDto eventDto);

        /// <summary>
        /// Зарегистрировать событие.
        /// </summary>
        /// <param name="eventDto">Информация о событии.</param>
        /// <returns>Результат.</returns>
        Task<EventResponseDto> RegisterAsync(UserEventDto eventDto);

        /// <summary>
        /// Зарегистрировать событие.
        /// </summary>
        /// <param name="eventDto">Информация о событии.</param>
        /// <returns>Результат.</returns>
        Task<EventResponseDto> RegisterAsync(PaymentEventDto eventDto);
    }
}
