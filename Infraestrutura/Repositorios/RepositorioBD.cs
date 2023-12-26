using Dominio;
using Dominio.Constantes;
using Dominio.Enums;
using Microsoft.Data.SqlClient;

namespace Infraestrutura.Repositorios
{
    public class RepositorioBD : IRepositorio
    {
        private const string NomeDaConexao = "ConexaoBD";
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[NomeDaConexao].ConnectionString;
        private static SqlConnection Connection()
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            return connection;
        }
        private static Funcionario NovoFuncionario(SqlDataReader reader)
        {
            Funcionario funcionario = new()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Cpf = reader["Cpf"].ToString(),
                Telefone = reader["Telefone"].ToString(),
                Salario = Convert.ToDecimal(reader["Salario"]),
                DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                EhCasado = Convert.ToBoolean(reader["EhCasado"]),
                Genero = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader["Genero"].ToString())
            };
            return funcionario;
        }
        public void Criar(Funcionario funcionario)
        {
            try
            {

                using (var conn = Connection())
                {
                    SqlCommand cmd = new($@"INSERT INTO TabFuncionarios (Nome,Cpf,Telefone,Salario,DataNascimento,EhCasado,Genero) 
                                    VALUES (
                                    '{funcionario.Nome}',
                                    '{funcionario.Cpf}',
                                    '{funcionario.Telefone}',
                                    {funcionario.Salario.ToString().Replace(",", ".")},
                                    '{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                    {Convert.ToByte(funcionario.EhCasado)},
                                    '{funcionario.Genero}')", conn);
                    cmd.ExecuteReader();
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
                Funcionario funcionario = null;
                using (var conn = Connection())
                {
                    SqlCommand cmd = new($"SELECT * FROM TabFuncionarios WHERE Id={id}", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        funcionario = NovoFuncionario(reader);
                    }
                }
                if (funcionario is null)
                {
                    throw new Exception(message: Excessoes.ERRO_AO_PESQUISAR_FUNCIONARIO);
                }
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
        public List<Funcionario> ObterTodos()
        {
            try
            {
                List<Funcionario> lista = new();
                using (var conn = Connection())
                {
                    SqlCommand cmd = new("SELECT * FROM TabFuncionarios", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(NovoFuncionario(reader));
                    }
                }
                return lista;
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
                using (var conn = Connection())
                {
                    SqlCommand cmd = new($@"UPDATE TabFuncionarios SET 
                                    Nome='{funcionario.Nome}',
                                    Cpf='{funcionario.Cpf}',
                                    Telefone='{funcionario.Telefone}',
                                    Salario={funcionario.Salario.ToString().Replace(",", ".")},
                                    DataNascimento='{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                    EhCasado={Convert.ToByte(funcionario.EhCasado)},
                                    Genero='{funcionario.Genero}' 
                                    WHERE Id={funcionario.Id}", conn);
                    cmd.ExecuteReader();
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
                using (var conn = Connection())
                {
                    SqlCommand cmd = new($"DELETE FROM TabFuncionarios WHERE id={funcionario.Id}", conn);
                    cmd.ExecuteReader();
                }
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
