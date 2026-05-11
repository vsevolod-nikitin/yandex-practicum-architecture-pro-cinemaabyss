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
        Task<EventResponseDto> RegisterMovieEventAsync(MovieEventDto eventDto);

        /// <summary>
        /// Зарегистрировать событие.
        /// </summary>
        /// <param name="eventDto">Информация о событии.</param>
        /// <returns>Результат.</returns>
        Task<EventResponseDto> RegisterUserEventAsync(UserEventDto eventDto);

        /// <summary>
        /// Зарегистрировать событие.
        /// </summary>
        /// <param name="eventDto">Информация о событии.</param>
        /// <returns>Результат.</returns>
        Task<EventResponseDto> RegisterPaymentEventAsync(PaymentEventDto eventDto);
    }
}
