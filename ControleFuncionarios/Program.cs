using FluentMigrator.Runner;
using Infraestrutura.Extensoes;
using Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InterfaceUsuario
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = CriaHostBuilder();
            using var build = builder.Build();
            var servicesProvider = build.Services;
            
            UpdateDataBase(servicesProvider);

            var forms = servicesProvider.GetService<TelaPrincipal>();

            Application.Run(forms);
        }
        private static void UpdateDataBase(IServiceProvider servicesProvider)
        {
            var runner = servicesProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
        private static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureContainer<IServiceCollection>((context, services) =>
                {
                    services.AddScoped<TelaPrincipal>();
                    services.AddScoped<IRepositorio, Repositorio>();
                    services.ExecutarMigracoes();
                });
        }
    }
}