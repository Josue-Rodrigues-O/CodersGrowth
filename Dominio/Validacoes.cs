using System.Text.RegularExpressions;

namespace Dominio
{
    public class Validacoes
    {
        private readonly List<string> ListaErros = new();
        public void Validar(string nome, string cpf, string telefone, string salario, DateTime calendario)
        {
            #region Nome
            if (String.IsNullOrWhiteSpace(nome))
            {
                ListaErros.Add(Excessoes.NomeNulo);
            }
            if (nome.Length < 3)
            {
                ListaErros.Add(Excessoes.TamanhoNomeIncompativel);
            }
            #endregion

            #region CPF
            if (cpf.Length < 14)
            {
                ListaErros.Add(Excessoes.CpfPreenchidoIncorrretamente);
            }
            #endregion

            #region Telefone
            if (telefone.Length < 16)
            {
                ListaErros.Add(Excessoes.TelefonePreenchidoIncorrretamente);
            }
            #endregion

            #region Salario
            if (string.IsNullOrWhiteSpace(salario))
            {
                ListaErros.Add(Excessoes.SalarioNulo);
            }
            if (!salario.Contains(',')
                || (salario.Split(',')[1].Length < 2)
                || (salario.Split(',')[1].Length > 2))
            {
                ListaErros.Add(Excessoes.NumeroIncorretoCasasDecimais);
            }
            if (salario.Length > 13)
            {
                ListaErros.Add(Excessoes.SalarioAbsurdo);
            }
            int contVirgula = 0;
            foreach (char index in salario)
            {
                if (index == ',')
                {
                    contVirgula++;
                }
            }
            if (contVirgula > 1)
            {
                ListaErros.Add(Excessoes.QuantidadeDeVirgulaInvalido);
            }
            if (Regex.IsMatch(salario, "[!@#$%¨&*()]"))
            {
                ListaErros.Add(Excessoes.SalarioContemCaracteresEspeciais);
            }
            #endregion

            #region Data de Nascimento
            int anos = DateTime.Now.Year - calendario.Date.Year;
            if (anos < 18)
            {
                ListaErros.Add(Excessoes.IdadeInvalida);
            }
            #endregion

            if(ListaErros.Any())
            {
                string erros = "";
                foreach(string index in ListaErros)
                {
                    erros += index+"\n";
                }
                throw new Exception(message: erros);
            }
        }
    }
}
