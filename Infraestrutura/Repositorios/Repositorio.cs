using Dominio;

namespace Infraestrutura.Repositorios
{
    public class Repositorio : IRepositorio
    {
        protected List<Funcionario> _listaFuncionarios;

        public Repositorio()
        {
            _listaFuncionarios = Singleton.ListaFuncionario();
        }

        public void Criar(Funcionario funcionario)
        {
            _listaFuncionarios.Add(funcionario);
        }

        public Funcionario ObterPorId(uint id)
        {
            return _listaFuncionarios.Find(x => x.Id == id);
        }

        public List<Funcionario> ObterTodos()
        {
            return _listaFuncionarios;
        }

        public void Remover(Funcionario funcionario)
        {
            _listaFuncionarios.Remove(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            var indice = _listaFuncionarios.FindIndex(func => func.Id == funcionario.Id);
            _listaFuncionarios[indice] = funcionario;
        }
    }
}
