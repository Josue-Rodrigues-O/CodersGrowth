using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration(20231130111200)]
    public class _20231130111200_UpdateTable : Migration
    {
        public override void Up()
        {
            Alter.Table("TabFuncionarios").AlterColumn("Salario").AsDecimal(12, 2).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TabFuncionarios");
        }
    }
}
