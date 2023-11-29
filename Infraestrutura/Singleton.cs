﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Infraestrutura
{
    public class Singleton
    {
        private static List<Funcionario> ListaFuncionarios;
        private static int _id;

        public static List<Funcionario> ListaFuncionario()
        {
            if(ListaFuncionarios == null)
            {
                ListaFuncionarios = new();
            }
            return ListaFuncionarios;
        }

        public static int IncrementarId()
        {
            _id++;
            return _id;
        }
    }
}
