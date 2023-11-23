using System;
using System.Linq;
using ControleFuncionarios.Migrations;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFuncionarios
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipal());
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                ///Adiciona servi�os comuns do FluentMigrator
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    ///Adiciona suporte SQLServer ao FluentMigrator
                    .AddSqlServer()
                    ///Define a string de conex�o
                    .WithGlobalConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString)
                    ///Define o assembly que cont�m as migra��es
                    .ScanIn(typeof(_20231121103000_AddFuncionariosTable).Assembly).For.Migrations())
                ///Habilita o log para console no modo FluentMigrator
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                ///Constr�i o provedor de servi�os
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            //GetRequiredService<IMigrationRunner>() obtem um servi�o do tipo IMigrationRunner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}
