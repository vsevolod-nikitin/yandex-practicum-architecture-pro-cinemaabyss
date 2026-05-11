using CinemaAbyss.Events.Implementation;
using CinemaAbyss.Events.Services;
using CinemaAbyss.Events.Services.Implementation;

namespace CinemaAbyss.Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ServiceConfiguration(builder.Configuration);
            builder.Services.AddSingleton<IServiceConfiguration>(configuration);

            builder.WebHost.UseUrls($"http://*:{configuration.Port}");

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            RegisterServices(builder.Services, configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapGet("/api/events/health", () => Results.Ok(new { status = true }));
            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Зарегистрировать сервисы. 
        /// </summary>
        /// <param name="services">Функционал построения.</param>
        /// <param name="configuration">Конфигурация функционала.</param>
        private static void RegisterServices(IServiceCollection services, ServiceConfiguration configuration)
        {
            services.AddScoped<IEventsProducer, EventsProducer>();
        }
    }
}
