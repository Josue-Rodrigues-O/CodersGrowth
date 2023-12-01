using Dominio;

namespace Infraestrutura
{
    public class Singleton
    {
        private static List<Funcionario> _listaFuncionarios = new();
        private static uint _id;

        public static List<Funcionario> ListaFuncionario()
        {
            if (_listaFuncionarios == null)
            {
                _listaFuncionarios = new();
            }
            return _listaFuncionarios;
        }

        public static uint IncrementarId()
        {
            _id++;
            return _id;
        }
    }
}
