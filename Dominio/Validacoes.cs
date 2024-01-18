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
            if (String.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome))
            {
                ListaErros.Add(Excessoes.NOME_NULO);
            }
            if (nome.Trim().Length < (int)ValoresValidacao.TamanhoMinNome)
            {
                ListaErros.Add(Excessoes.TAMANHO_NOME_INCOMPATIVEL);
            }
            if (nome.Length >= (int)ValoresValidacao.TamanhoMaxNome)
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
            if (cpf.Length < (int)ValoresValidacao.TamanhoCorretoCpf || string.IsNullOrEmpty(cpf))
            {
                ListaErros.Add(Excessoes.CPF_PREENCHIDO_INCORRETAMENTE);
            }
        }
        public void ValidarTelefone(string telefone)
        {
            if (telefone.Length < (int)ValoresValidacao.TamanhoCorretoTelefone || string.IsNullOrEmpty(telefone))
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

            if (string.IsNullOrEmpty(salario) || string.IsNullOrWhiteSpace(salario))
            {
                ListaErros.Add(Excessoes.SALARIO_NULO);
            }
            else
            {
                if (Convert.ToDecimal(salario) < (int)ValoresValidacao.TamanhoMinSalario)
                {
                    ListaErros.Add(Excessoes.SALARIO_INVALIDO);
                }
            }
            if (!salario.Contains(Virgula)
                || (salario.Split(Virgula)[ParteDecimalSalario].Length < (int)ValoresValidacao.QuantidadeCasasDecimaisSalario)
                || (salario.Split(Virgula)[ParteDecimalSalario].Length > (int)ValoresValidacao.QuantidadeCasasDecimaisSalario))
            {
                ListaErros.Add(Excessoes.NUMERO_INCORRETO_DE_CASAS_DECIMAIS);
            }
            if (salario.Length > (int)ValoresValidacao.TamanhoMaxSalario)
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
            if (contVirgula > (int)ValoresValidacao.QuantidadeDeVirgulaMax)
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
            if (String.IsNullOrWhiteSpace(salario.Split(Virgula)[ParteInteiraSalario])
                || String.IsNullOrEmpty(salario.Split(Virgula)[ParteInteiraSalario]))
            {
                ListaErros.Add(Excessoes.SALARIO_INVALIDO);
            }
        }
        public void ValidarDataNascimento(DateTime dataNascimento)
        {
            int anos = DateTime.Now.Year - dataNascimento.Date.Year;
            if (anos < (int)ValoresValidacao.IdadeMinima)
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
