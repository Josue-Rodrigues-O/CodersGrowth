using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    public sealed class Singleton
    {
        public List<Funcionario> ListaFuncionarios { get; }
        private int _id;
        private Singleton()
        {
            ListaFuncionarios = new();
        }
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public int IncrementarId()
        {
            _id++;
            return _id;
        }
    }
}
