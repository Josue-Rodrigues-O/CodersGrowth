using Dominio;

namespace Infraestrutura
{
    public class Singleton
    {
        private static List<Funcionario> _listaFuncionarios;
        private static int _id;

        public static List<Funcionario> ListaFuncionario()
        {
            if (_listaFuncionarios == null)
            {
                _listaFuncionarios = new();
            }
            return _listaFuncionarios;
        }

        public static int IncrementarId()
        {
            _id++;
            return _id;
        }
    }
}
