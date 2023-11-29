using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration(20231124130000)]
    public class _20231124130000_AddFuncionariosTable : Migration
    {
        public override void Up()
        {
            Create.Table("TabFuncionarios")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("Salario").AsDecimal().NotNullable()
                .WithColumn("EhCasado").AsBoolean().NotNullable()
                .WithColumn("DataNascimento").AsDate().NotNullable()
                .WithColumn("Genero").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TabFuncionarios");
        }
    }
}
