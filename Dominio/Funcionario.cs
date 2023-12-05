using Dominio.Enums;
using LinqToDB;
using LinqToDB.Mapping;
namespace Dominio
{
    [Table("TabFuncionarios")]
    public class Funcionario
    {
        [PrimaryKey, Identity, NotNull]
        public uint Id { get; set; }
        [NotNull, Column("Nome")]
        public string Nome { get; set; } = string.Empty;
        [NotNull, Column("Cpf")]
        public string Cpf { get; set; } = string.Empty;
        [NotNull, Column("Telefone")]
        public string Telefone { get; set; } = string.Empty;
        [NotNull, Column("Salario")]
        public decimal Salario { get; set; } = decimal.Zero;
        [NotNull, Column("EhCasado")]
        public bool EhCasado { get; set; }
        [NotNull, Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
        [NotNull, Column("Genero")]
        public GeneroEnum Genero { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}