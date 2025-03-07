using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Filters;
using TestUdv.BAL.Services;
using TestUdv.Core.Interfaces;
using TestUdv.DAL;
using TestUdv.DAL.Repositories;
using TestUdvInfrastructure;


namespace TestUdv.API
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IVKService, VKService>();
            services.AddScoped<ICountingOccurrence, CountingOccurrence>();

            services.AddDbContext<TestUdvDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(TestUdvDbContext)));
            });


            var fileLogger = new LoggerConfiguration()
            .Filter.ByIncludingOnly(Matching.FromSource("TestUdvInfrastructure.CountingOccurrence"))
            .WriteTo.File("Logs/logs.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Logger(fileLogger)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog();
            });

        }
    }
}
