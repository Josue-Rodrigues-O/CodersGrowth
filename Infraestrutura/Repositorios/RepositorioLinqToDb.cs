using Dominio;
using Dominio.Constantes;
using LinqToDB;
using LinqToDB.Data;

namespace Infraestrutura.Repositorios
{
    public class RepositorioLinqToDb : IRepositorio
    {
        private DataConnection Conexao()
        {
            return new(new DataOptions()
            .UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString));
        }
        public void Criar(Funcionario funcionario)
        {
            try
            {
                using (var conn = Conexao())
                {
                    conn.Insert(new Funcionario
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
                using (var conn = Conexao())
                {
                    var listaBD = conn.GetTable<Funcionario>().Where(x => x.Id == id).ToList();
                    foreach (var item in listaBD)
                    {
                        funcionario = item;
                    }
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
                using (var conn = Conexao())
                {
                    return conn.GetTable<Funcionario>().ToList();
                }
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
                using (var conn = Conexao())
                {
                    conn.Update(funcionario);
                }
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
                using (var conn = Conexao())
                {
                    conn.Delete(funcionario);
                }
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
