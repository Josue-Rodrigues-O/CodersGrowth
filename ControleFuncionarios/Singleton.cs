using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    public class Singleton
    {
        private static List<Funcionario> ListaFuncionario;

        public static List<Funcionario> listaFuncionario()
        {
            if(ListaFuncionario == null)
            {
                ListaFuncionario = new();
            }
            return ListaFuncionario;
        }

        private static int _id;
        public static int IncrementarId()
        {
            _id++;
            return _id;
        }
    }
}
