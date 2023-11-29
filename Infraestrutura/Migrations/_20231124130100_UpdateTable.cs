using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration (20231124132500)]
    public class _20231124132500_UpdateTable : Migration
    {
        public override void Up()
        {
            Alter.Table("TabFuncionarios").AlterColumn("Salario").AsDecimal(12,2).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TabFuncionarios");
        }
    }
}
