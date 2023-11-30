using Interacao;
using Infraestrutura;
using Dominio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentMigrator.Runner;
using Infraestrutura.Extensoes;

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
            UpdateDataBase(servicesProvider);

            var form = servicesProvider.GetService<TelaPrincipal>();
            Application.Run(form);
        }
        private static void UpdateDataBase(IServiceProvider servicesProvider)
        {
            var runner = servicesProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        private static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<TelaPrincipal>();
                    services.AddScoped<IRepositorio, RepositorioBD>();
                    services.ExecutarMigations(); //=======================
                });
        }
    }
}
