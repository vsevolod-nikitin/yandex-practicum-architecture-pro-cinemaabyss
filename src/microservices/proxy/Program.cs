using CinemaAbyss.Proxy.Implementation;
using CinemaAbyss.Proxy.Services;
using CinemaAbyss.Proxy.Services.Implementation;
using CinemaAbyss.Proxy.Services.Legacy;
using CinemaAbyss.Proxy.Services.Micro;

namespace CinemaAbyss.Proxy
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

            RegisterMoviesService(builder.Services, configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapControllers();

            app.Run();
        }

        private static void RegisterMoviesService(IServiceCollection services, ServiceConfiguration configuration)
        {
            services.AddHttpClient(nameof(LegacyMoviesService), client =>
            {
                client.BaseAddress = new Uri(configuration.MonolithUrl);
            });
            services.AddHttpClient(nameof(MicroMoviesService), client =>
            {
                client.BaseAddress = new Uri(configuration.MoviesServiceUrl);
            });

            services.AddKeyedScoped<IMoviesService, LegacyMoviesService>(ServiceType.Legacy);
            services.AddKeyedScoped<IMoviesService, MicroMoviesService>(ServiceType.Micro);
            services.AddScoped<IMoviesService, MoviesServiceResolver>();
        }
    }
}
