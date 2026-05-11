using System.Text.Json.Serialization;

namespace CinemaAbyss.Events.Model
{
    /// <summary>
    /// Событие, связанное с платежом.
    /// </summary>
    public sealed class PaymentEventDto
    {
        /// <summary>
        /// Идентификатор платежа.
        /// </summary>
        [JsonPropertyName("payment_id")]
        public required long PaymentId { get; init; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [JsonPropertyName("user_id")]
        public required long UserId { get; init; }

        /// <summary>
        /// Сумма платежа.
        /// </summary>
        [JsonPropertyName("amount")]
        public required decimal Amount { get; init; }

        /// <summary>
        /// Статус платежа.
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>
        /// Время платежа.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public required DateTime Timestamp { get; init; }

        /// <summary>
        /// Тип метода оплаты.
        /// </summary>
        [JsonPropertyName("method_type")]
        public string? MethodType { get; init; }
    }
}
