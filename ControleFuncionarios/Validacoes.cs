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
        public void ValidarNome(string nome)
        {
            Regex rx = new Regex("[0-9]");
            if (nome == null)
            {
                throw new ArgumentNullException();
            }
            if (Regex.IsMatch(nome,"[0-9-]"))
            {
                throw new Exception(message: "O nome não pode conter numeros");
            }
        }
    }
}
