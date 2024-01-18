using FluentMigrator;
using Dominio.Constantes;

namespace Infraestrutura.Migrations
{
    [Migration(20231124130000)]
    public class _20231124130000_AddFuncionariosTable : Migration
    {
        public override void Up()
        {
            Create.Table(CamposTabelaBD.NOME_DA_TABELA)
                .WithColumn(CamposTabelaBD.COLUNA_ID).AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn(CamposTabelaBD.COLUNA_NOME).AsString().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_CPF).AsString().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_TELEFONE).AsString().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_SALARIO).AsDecimal().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_EHCASADO).AsBoolean().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_DATA_NASCIMENTO).AsDate().NotNullable()
                .WithColumn(CamposTabelaBD.COLUNA_GENERO).AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(CamposTabelaBD.NOME_DA_TABELA);
        }
    }
}
