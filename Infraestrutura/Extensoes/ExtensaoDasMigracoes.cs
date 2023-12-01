using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infraestrutura.Extensoes
{
    public static class ExtensaoDasMigracoes
    {
        public static void ExecutarMigracoes(this IServiceCollection servico)
        {
            const string NomeDaConexao = "ConexaoBD";
            servico.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings[NomeDaConexao].ConnectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}
