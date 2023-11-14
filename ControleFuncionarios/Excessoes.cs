using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    static class Excessoes
    {
        public const string NomeNulo = "O campo Nome não pode ser nulo!";
        public const string TamanhoNomeIncompativel = "O campo Nome deve conter pelo menos três caracteres!";
        public const string CpfPreenchidoIncorrretamente = "O campo CPF deve ser preenchido corretamente!";
        public const string TelefonePreenchidoIncorrretamente = "O campo Telefone deve ser preenchido corretamente!";
        public const string SalarioNulo = "O campo Salário não pode ser nulo!";
        public const string NumeroIncorretoCasasDecimais = "O campo Salário deve conter duas casas decimais após a vírgula!";
        public const string IdadeInvalida = "O funcionário não pode ter menos de 18 anos!";
        public const string QuantidadeDeVirgulaInvalido = "O campo Salário não pode ter mais de uma virgula!";
        public const string SalarioContemCaracteresEspeciais = "O campo Salário não pode conter caracteres especiais!";
    }
}
