using FluentMigrator.Runner;
using Infraestrutura;
using Infraestrutura.Extensoes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Interacao
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = CriaHostBuilder();
            using var build = builder.Build();

            var servicesProvider = build.Services;
            using var scope = servicesProvider.CreateScope();
            
            UpdateDatabase(scope.ServiceProvider);

            var form = servicesProvider
                .GetRequiredService<TelaPrincipal>();

            Application.Run(form);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider
                .GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<TelaPrincipal>();
                    services.AddScoped<IRepositorio, RepositorioBD>();
                    services.ExecutarMigracoes();
                });
        }
    }
}
