using System.Globalization;
using System.Text.RegularExpressions;
using Dominio.Constantes;
using Dominio.Enums;
namespace Dominio
{
    public class Validacoes
    {
        private readonly List<string> ListaErros = new();
        public void ValidarCampos(string nome, string cpf, string telefone, string salario, DateTime dataNascimento, int genero)
        {
            string quebraDeLinha = "\n";
            ValidarNome(nome);
            ValidarCpf(cpf);
            ValidarTelefone(telefone);
            ValidarSalario(salario);
            ValidarDataNascimento(dataNascimento);
            ValidarGenero(genero);

            if (ListaErros.Any())
            {
                string erros = String.Empty;
                foreach (string index in ListaErros)
                {
                    erros += index + quebraDeLinha;
                }
                throw new Exception(message: erros);
            }
        }
        public void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                ListaErros.Add(Excessoes.NOME_NULO);
            }
            if (nome.Trim().Length < ValoresValidacao.TAMANHO_MINIMO_NOME)
            {
                ListaErros.Add(Excessoes.TAMANHO_NOME_INCOMPATIVEL);
            }
            if (nome.Length >= ValoresValidacao.TAMANHO_MAXIMO_NOME)
            {
                ListaErros.Add(Excessoes.TAMANHO_MAX_NOME_INCOMPATIVEL);
            }
            foreach (char index in nome)
            {
                if (!Regex.IsMatch(index.ToString(), ExpressoesRegex.REGEX_NOME))
                {
                    ListaErros.Add(Excessoes.NOME_CONTEM_CARACTERES_ESPECIAIS);
                    break;
                }
            }
        }
        public void ValidarCpf(string cpf)
        {
            if (cpf.Length < ValoresValidacao.TAMANHO_CORRETO_CPF || string.IsNullOrEmpty(cpf))
            {
                ListaErros.Add(Excessoes.CPF_PREENCHIDO_INCORRETAMENTE);
            }
        }
        public void ValidarTelefone(string telefone)
        {
            if (telefone.Length < ValoresValidacao.TAMANHO_CORRETO_TELEFONE || string.IsNullOrEmpty(telefone))
            {
                ListaErros.Add(Excessoes.TELEFONE_PREENCHIDO_INCORRETAMENTE);
            }
        }
        public void ValidarSalario(string salario)
        {
            const char Virgula = ',';
            const byte ParteInteiraSalario = 0;
            const byte ParteDecimalSalario = 1;
            byte contVirgula = byte.MinValue;

            if (string.IsNullOrWhiteSpace(salario))
            {
                ListaErros.Add(Excessoes.SALARIO_NULO);
            }
            else if (Convert.ToDecimal(salario) < ValoresValidacao.TAMANHO_MINIMO_SALARIO)
            {
                ListaErros.Add(Excessoes.SALARIO_INVALIDO);
            }

            if (!salario.Contains(Virgula)
                || (salario.Split(Virgula)[ParteDecimalSalario].Length != ValoresValidacao.QUANTIDADE_CASAS_DECIMAIS_SALARIO))
            {
                ListaErros.Add(Excessoes.NUMERO_INCORRETO_DE_CASAS_DECIMAIS);
            }
            if (salario.Length > ValoresValidacao.TAMANHO_MAXIMO_SALARIO)
            {
                ListaErros.Add(Excessoes.VALOR_DO_SALARIO_MUITO_ALTO);
            }
            foreach (char index in salario)
            {
                if (index == Virgula)
                {
                    contVirgula++;
                }
            }
            if (contVirgula > ValoresValidacao.QUANTIDADE_MAXIMA_DE_VIRGULA)
            {
                ListaErros.Add(Excessoes.QUANTIDADE_DE_VIRGULAS_INVALIDAS);
            }

            foreach (char index in salario)
            {
                if (!Regex.IsMatch(index.ToString(), ExpressoesRegex.REGEX_SALARIO))
                {
                    ListaErros.Add(Excessoes.SALARIO_CONTEM_CARACTERES_ESPECIAIS);
                    break;
                }
            }
            if (String.IsNullOrWhiteSpace(salario.Split(Virgula)[ParteInteiraSalario]))
            {
                ListaErros.Add(Excessoes.SALARIO_INVALIDO);
            }
        }
        public void ValidarDataNascimento(DateTime dataNascimento)
        {
            int anos = DateTime.Now.Year - dataNascimento.Date.Year;
            if (anos < ValoresValidacao.IDADE_MINIMA)
            {
                ListaErros.Add(Excessoes.IDADE_INVALIDA);
            }
        }
        public void ValidarGenero(int genero)
        {
            if (genero != (int)GeneroEnum.Indefinido
                && genero != (int)GeneroEnum.Masculino
                && genero != (int)GeneroEnum.Feminino)
            {
                ListaErros.Add(Excessoes.VALOR_DO_GENERO_INVALIDO);
            }
        }
    }
}
