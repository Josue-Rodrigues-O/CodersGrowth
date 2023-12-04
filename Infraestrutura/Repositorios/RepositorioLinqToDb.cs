using Dominio;
using Dominio.Constantes;
using LinqToDB;
using LinqToDB.Data;

namespace Infraestrutura.Repositorios
{
    public class RepositorioLinqToDb : IRepositorio
    {
        private readonly DataConnection Connection =
            new(new DataOptions()
            .UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString));

        public void Criar(Funcionario funcionario)
        {
            try
            {
                Connection.Insert(new Funcionario
                {
                    Nome = funcionario.Nome,
                    Cpf = funcionario.Cpf,
                    DataNascimento = funcionario.DataNascimento,
                    EhCasado = funcionario.EhCasado,
                    Genero = funcionario.Genero,
                    Salario = funcionario.Salario,
                    Telefone = funcionario.Telefone
                });
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
                Funcionario funcionario = new();

                var a = Connection.GetTable<Funcionario>().Where(x => x.Id == id).ToList();
                foreach (var item in a)
                {
                    funcionario = item;
                }
                return funcionario;
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
                return Connection.GetTable<Funcionario>().ToList();
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
                Connection.Update(funcionario);
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
                Connection.Delete(funcionario);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
