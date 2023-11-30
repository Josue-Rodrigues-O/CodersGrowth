using System.Text.RegularExpressions;
using Dominio.Enums;
namespace Dominio
{
    public class Validacoes
    {
        private readonly List<string> _listaErros;
        public Validacoes()
        {
            _listaErros = new();
        }
        public void ValidarCampos(string nome, string cpf, string telefone, string salario, DateTime calendario)
        {
            #region Nome
            if (String.IsNullOrWhiteSpace(nome))
            {
                _listaErros.Add(Excessoes.NOME_NULO);
            }
            if (nome.Length < (int)ValoresValidacaoEnum.TamanhoMinNome)
            {
                _listaErros.Add(Excessoes.TAMANHO_NOME_INCOMPATIVEL);
            }
            foreach (char index in nome)
            {
                if (!Regex.IsMatch(index.ToString(), "[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]"))
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
            if (!salario.Contains(',')
                || (salario.Split(',')[1].Length < (int)ValoresValidacaoEnum.QuantidadeCasasDecimaisSalario)
                || (salario.Split(',')[1].Length > (int)ValoresValidacaoEnum.QuantidadeCasasDecimaisSalario))
            {
                _listaErros.Add(Excessoes.NUMERO_INCORRETO_DE_CASAS_DECIMAIS);
            }
            if (salario.Length > (int)ValoresValidacaoEnum.TamanhoMaxSalario)
            {
                _listaErros.Add(Excessoes.VALOR_DO_SALARIO_MUITO_ALTO);
            }
            int contVirgula = 0;
            foreach (char index in salario)
            {
                if (index == ',')
                {
                    contVirgula++;
                }
            }
            if (contVirgula > (int)ValoresValidacaoEnum.QuantidadeDeVirgulaMax)
            {
                _listaErros.Add(Excessoes.QUANTIDADE_DE_VIRGULAS_INVALIDAS);
            }
            if (!Regex.IsMatch(salario, "[0-9,]"))
            {
                _listaErros.Add(Excessoes.SALARIO_CONTEM_CARACTERES_ESPECIAIS);
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
                string erros = "";
                foreach (string index in _listaErros)
                {
                    erros += index + "\n";
                }
                throw new Exception(message: erros);
            }
        }
    }
}
