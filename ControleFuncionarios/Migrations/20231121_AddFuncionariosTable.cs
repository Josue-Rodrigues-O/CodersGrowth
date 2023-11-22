using FluentMigrator;

namespace ControleFuncionarios.Migrations
{
    [Migration(20231121103000)]
    public class _20231121103000_AddFuncionariosTable : Migration
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
                .WithColumn("DataNascimeno").AsDate().NotNullable()
                .WithColumn("Genero").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TabFuncionarios");
        }
    }
}
