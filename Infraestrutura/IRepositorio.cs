using Dominio;

namespace Infraestrutura
{
    public interface IRepositorio
    {
        public List<Funcionario> ObterTodos();
        public Funcionario ObterPorId(uint id);
        public void Criar(Funcionario funcionario);
        public void Remover(Funcionario funcionario);
        public void Atualizar(Funcionario funcionario);
    }
}
