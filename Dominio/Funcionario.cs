using Dominio.Enums;
using LinqToDB.Mapping;
using Dominio.Constantes;
namespace Dominio
{
    [Table(CamposTabelaBD.NOME_DA_TABELA)]
    public class Funcionario
    {
        [PrimaryKey, Identity, NotNull]
        public int Id { get; set; }
        [NotNull, Column(CamposTabelaBD.COLUNA_NOME)]
        public string Nome { get; set; } = string.Empty;
        [NotNull, Column(CamposTabelaBD.COLUNA_CPF)]
        public string Cpf { get; set; } = string.Empty;
        [NotNull, Column(CamposTabelaBD.COLUNA_TELEFONE)]
        public string Telefone { get; set; } = string.Empty;
        [NotNull, Column(CamposTabelaBD.COLUNA_SALARIO)]
        public decimal Salario { get; set; } = decimal.Zero;
        [NotNull, Column(CamposTabelaBD.COLUNA_EHCASADO)]
        public bool EhCasado { get; set; }
        [NotNull, Column(CamposTabelaBD.COLUNA_DATA_NASCIMENTO)]
        public DateTime DataNascimento { get; set; }
        [NotNull, Column(CamposTabelaBD.COLUNA_GENERO)]
        public GeneroEnum Genero { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}