using CinemaAbyss.Proxy.Implementation;

namespace CinemaAbyss.Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ServiceConfiguration(builder.Configuration);
            builder.Services.AddSingleton<IServiceConfiguration>(configuration);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(configuration.Port);
            });

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
