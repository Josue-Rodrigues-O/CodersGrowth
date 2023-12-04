using Dominio.Enums;
using LinqToDB;
using LinqToDB.Mapping;

namespace Dominio
{
    [Table("TabFuncionarios")]
    public class Funcionario
    {
        [PrimaryKey,Identity,NotNull]
        public uint Id { get; set; }
        [Column("Nome"),NotNull]
        public string Nome { get; set; } = string.Empty;
        [Column("Cpf"),NotNull]
        public string Cpf { get; set; } = string.Empty;
        [Column("Telefone"), NotNull]
        public string Telefone { get; set; } = string.Empty;
        [Column("Salario"), NotNull]
        public decimal Salario { get; set; } = decimal.Zero;
        [Column("EhCasado"), NotNull]
        public bool EhCasado { get; set; }
        [Column("DataNascimento"), NotNull]
        public DateTime DataNascimento { get; set; }
        [Column("Genero"), NotNull]
        public GeneroEnum Genero { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}