using Dominio;
using Dominio.Constantes;

namespace Infraestrutura.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public void Criar(Funcionario funcionario)
        {
            try
            {
                funcionario.Id = Singleton.IncrementarId();
                Singleton.ListaFuncionario().Add(funcionario);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_CADASTRAR_FUNCIONARIO);
            }
        }

        public Funcionario ObterPorId(int id)
        {
            try
            {
                return Singleton.ListaFuncionario().FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_PESQUISAR_FUNCIONARIO);
            }
        }

        public List<Funcionario> ObterTodos()
        {
            try
            {
                return Singleton.ListaFuncionario();
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS);
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            try
            {
                var indice = Singleton.ListaFuncionario().FindIndex(func => func.Id == funcionario.Id);
                Singleton.ListaFuncionario()[indice] = funcionario;
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_ALTERAR_FUNCIONARIO);
            }
        }

        public void Remover(Funcionario funcionario)
        {
            try
            {
                Singleton.ListaFuncionario().Remove(funcionario);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
