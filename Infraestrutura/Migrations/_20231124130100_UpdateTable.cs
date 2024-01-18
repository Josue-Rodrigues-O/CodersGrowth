using FluentMigrator;
using Dominio.Constantes;

namespace Infraestrutura.Migrations
{
    [Migration(20231130111200)]
    public class _20231130111200_UpdateTable : Migration
    {
        public override void Up()
        {
            const int tamanhoMaximo = 12;
            const int precisao = 2;
            Alter.Table(CamposTabelaBD.NOME_DA_TABELA)
                .AlterColumn(CamposTabelaBD.COLUNA_SALARIO)
                .AsDecimal(tamanhoMaximo, precisao)
                .NotNullable();
        }

        public override void Down()
        {
            Delete.Table(CamposTabelaBD.NOME_DA_TABELA);
        }
    }
}
