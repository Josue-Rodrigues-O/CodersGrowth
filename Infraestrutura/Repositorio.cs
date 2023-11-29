using Dominio;

namespace Infraestrutura
{
    public class Repositorio : IRepositorio
    {
        protected List<Funcionario> ListaFuncionarios = Singleton.ListaFuncionario();

        public void Criar(Funcionario funcionario)
        {
            ListaFuncionarios.Add(funcionario);
        }

        public Funcionario ObterPorId(int id)
        {
            return ListaFuncionarios.Find(x => x.Id == id);
        }

        public List<Funcionario> ObterTodos()
        {
            return ListaFuncionarios;
        }

        public void Remover(Funcionario funcionario)
        {
            ListaFuncionarios.Remove(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            var indice = ListaFuncionarios.FindIndex(func => func.Id == funcionario.Id);
            ListaFuncionarios[indice] = funcionario;
        }
    }
}
