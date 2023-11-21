using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    [Migration(20231121103000)]
    public class AddFuncionariosTable : Migration
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
