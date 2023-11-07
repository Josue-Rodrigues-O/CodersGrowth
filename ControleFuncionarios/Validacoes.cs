using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    internal class Validacoes
    {
        public bool ValidarNome(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome))
            {
                throw new Exception(message: Excessoes.NomeNulo);
            }
            if(nome.Length < 3)
            {
                throw new Exception(message: Excessoes.TamanhoNomeIncompativel);
            }
            return true;
        }
        public bool ValidarCpf(MaskedTextBox cpf)
        {
            if (!cpf.MaskCompleted)
            {
                throw new Exception(message: Excessoes.CpfPreenchidoIncorrretamente);
            }

            return true;
        }
        public bool ValidarTelefone(MaskedTextBox telefone)
        {
            if (!telefone.MaskCompleted)
            {
                throw new Exception(message: Excessoes.TelefonePreenchidoIncorrretamente);
            }

            return true;
        }
        public bool ValidarSalario(string salario)
        {
            int contVirgula = 0;
            if(String.IsNullOrWhiteSpace(salario))
            {
                throw new Exception(message: Excessoes.SalarioNulo);
            }
            if (!salario.Contains(',') 
                || (salario.Split(',')[1].Length < 2) 
                || (salario.Split(',')[1].Length > 2))
            {
                throw new Exception(message: Excessoes.NumeroIncorretoCasasDecimais);
            }
            foreach(char index in salario)
            {
                if (index == ',')
                {
                    contVirgula++;
                }
            }
            if(contVirgula > 1)
            {
                throw new Exception(message: Excessoes.QuantidadeDeVirgulaInvalido);
            }

            return true;
        }
        public bool ValidarData(MonthCalendar calendario)
        {
            int anos = DateTime.Now.Year - calendario.SelectionStart.Year;
            if(anos < 18)
            {
                throw new Exception(message: Excessoes.IdadeInvalida);
            }
            return true;
        }
    }
}
