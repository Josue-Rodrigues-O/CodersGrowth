using Dominio;
using Dominio.Enums;
using Microsoft.Data.SqlClient;

namespace Infraestrutura
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
        public void Atualizar(Funcionario funcionario)
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

        public void Criar(Funcionario funcionario)
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

        public Funcionario ObterPorId(uint id)
        {
            Funcionario funcionario = new();
            using (var conn = Connection())
            {
                SqlCommand cmd = new($"SELECT * FROM TabFuncionarios WHERE Id={id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    funcionario = NovoFuncionario(reader);
                }
            }
            return funcionario;
        }

        public List<Funcionario> ObterTodos()
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

        public void Remover(Funcionario funcionario)
        {
            using (var conn = Connection())
            {
                SqlCommand cmd = new($"DELETE FROM TabFuncionarios WHERE id={funcionario.Id}", conn);
                cmd.ExecuteReader();
            }
        }

        private static Funcionario NovoFuncionario(SqlDataReader reader)
        {
            Funcionario funcionario = new()
            {
                Id = Convert.ToUInt32(reader["Id"]),
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
    }
}
