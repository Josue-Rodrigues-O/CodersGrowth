using System.Text.RegularExpressions;
using Dominio.Constantes;
using Dominio.Enums;
namespace Dominio
{
    public class Validacoes
    {
        private readonly List<string> _listaErros = new();
        public void ValidarCampos(string nome, string cpf, string telefone, string salario, DateTime calendario)
        {
            const char Virgula = ',';
            const byte SegundoValorVetor = 1;
            #region Nome
            if (String.IsNullOrWhiteSpace(nome))
            {
                _listaErros.Add(Excessoes.NOME_NULO);
            }
            if (nome.Trim().Length < (int)ValoresValidacaoEnum.TamanhoMinNome)
            {
                _listaErros.Add(Excessoes.TAMANHO_NOME_INCOMPATIVEL);
            }
            if (nome.Length >= (int)ValoresValidacaoEnum.TamanhoMaxNome)
            {
                _listaErros.Add(Excessoes.TAMANHO_MAX_NOME_INCOMPATIVEL);
            }
            foreach (char index in nome)
            {
                if (!Regex.IsMatch(index.ToString(), ExpressoesRegex.REGEX_NOME))
                {
                    _listaErros.Add(Excessoes.NOME_CONTEM_CARACTERES_ESPECIAIS);
                    break;
                }
            }
            #endregion

            #region CPF
            if (cpf.Length < (int)ValoresValidacaoEnum.TamanhoCorretoCpf)
            {
                _listaErros.Add(Excessoes.CPF_PREENCHIDO_INCORRETAMENTE);
            }
            #endregion

            #region Telefone
            if (telefone.Length < (int)ValoresValidacaoEnum.TamanhoCorretoTelefone)
            {
                _listaErros.Add(Excessoes.TELEFONE_PREENCHIDO_INCORRETAMENTE);
            }
            #endregion

            #region Salario
            if (string.IsNullOrWhiteSpace(salario))
            {
                _listaErros.Add(Excessoes.SALARIO_NULO);
            }
            if (!salario.Contains(Virgula)
                || (salario.Split(Virgula)[SegundoValorVetor].Length < (int)ValoresValidacaoEnum.QuantidadeCasasDecimaisSalario)
                || (salario.Split(Virgula)[SegundoValorVetor].Length > (int)ValoresValidacaoEnum.QuantidadeCasasDecimaisSalario))
            {
                _listaErros.Add(Excessoes.NUMERO_INCORRETO_DE_CASAS_DECIMAIS);
            }
            if (salario.Length > (int)ValoresValidacaoEnum.TamanhoMaxSalario)
            {
                _listaErros.Add(Excessoes.VALOR_DO_SALARIO_MUITO_ALTO);
            }
            byte contVirgula = byte.MinValue;
            foreach (char index in salario)
            {
                if (index == Virgula)
                {
                    contVirgula++;
                }
            }
            if (contVirgula > (int)ValoresValidacaoEnum.QuantidadeDeVirgulaMax)
            {
                _listaErros.Add(Excessoes.QUANTIDADE_DE_VIRGULAS_INVALIDAS);
            }

            foreach (char index in salario)
            {
                if (!Regex.IsMatch(index.ToString(), ExpressoesRegex.REGEX_SALARIO))
                {
                    _listaErros.Add(Excessoes.SALARIO_CONTEM_CARACTERES_ESPECIAIS);
                    break;
                }
            }
            #endregion

            #region Data de Nascimento
            int anos = DateTime.Now.Year - calendario.Date.Year;
            if (anos < (int)ValoresValidacaoEnum.IdadeMinima)
            {
                _listaErros.Add(Excessoes.IDADE_INVALIDA);
            }
            #endregion

            if (_listaErros.Any())
            {
                string erros = String.Empty;
                foreach (string index in _listaErros)
                {
                    erros += index + "\n";
                }
                throw new Exception(message: erros);
            }
        }
    }
}
