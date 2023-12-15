using Dominio;
using Dominio.Constantes;

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
            try
            {
                funcionario.Id = Singleton.IncrementarId();
                _listaFuncionarios.Add(funcionario);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_CADASTRAR_FUNCIONARIO);
            }
        }

        public Funcionario ObterPorId(uint id)
        {
            try
            {
                return _listaFuncionarios.First(x => x.Id == id);
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
                return _listaFuncionarios;
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
                var indice = _listaFuncionarios.FindIndex(func => func.Id == funcionario.Id);
                _listaFuncionarios[indice] = funcionario;
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
                _listaFuncionarios.Remove(funcionario);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
