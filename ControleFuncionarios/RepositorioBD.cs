using ControleFuncionarios.Enums;
using Microsoft.Data.SqlClient;

namespace ControleFuncionarios
{
    public class RepositorioBD : IRepositorio
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        private readonly SqlConnection connection = new(connectionString);

        public void Atualizar(Funcionario funcionario)
        {
            connection.Open();
            SqlCommand cmd = new($@"UPDATE TabFuncionarios SET 
                                    Nome='{funcionario.Nome}',
                                    Cpf='{funcionario.Cpf}',
                                    Telefone='{funcionario.Telefone}',
                                    Salario={funcionario.Salario.ToString().Replace(",", ".")},
                                    DataNascimento='{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                    EhCasado={Convert.ToByte(funcionario.EhCasado)},
                                    Genero='{funcionario.Genero}' 
                                    WHERE Id={funcionario.Id}", connection);
            cmd.ExecuteReader();
            connection.Close();
        }

        public void Criar(Funcionario funcionario)
        {
            connection.Open();
            SqlCommand cmd = new($@"INSERT INTO TabFuncionarios (Nome,Cpf,Telefone,Salario,DataNascimento,EhCasado,Genero) 
                                    VALUES (
                                    '{funcionario.Nome}',
                                    '{funcionario.Cpf}',
                                    '{funcionario.Telefone}',
                                    {funcionario.Salario.ToString().Replace(",", ".")},
                                    '{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                    {Convert.ToByte(funcionario.EhCasado)},
                                    '{funcionario.Genero}')", connection);
            cmd.ExecuteReader();
            connection.Close();
        }

        public Funcionario ObterPorId(int id)
        {
            Funcionario? funcionario = null;
            connection.Open();
            SqlCommand cmd = new($"SELECT * FROM TabFuncionarios WHERE Id={id}", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                funcionario = NovoFuncionario(reader);
            }
            connection.Close();
            return funcionario;
        }

        public List<Funcionario> ObterTodos()
        {
            List<Funcionario> lista = new();
            connection.Open();
            SqlCommand cmd = new("SELECT * FROM TabFuncionarios", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(NovoFuncionario(reader));
            }
            connection.Close();
            return lista;
        }

        public void Remover(Funcionario funcionario)
        {
            var remover = MessageBox.Show($"Deseja realmente remover o funcionário {funcionario.Nome} do banco de dados?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (remover.Equals(DialogResult.Yes))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM TabFuncionarios WHERE id={funcionario.Id}", connection);
                cmd.ExecuteReader();
                connection.Close();
            }
        }

        private static Funcionario NovoFuncionario(SqlDataReader reader)
        {
            Funcionario funcionario = new()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Cpf = reader["Cpf"].ToString(),
                Telefone = reader["Telefone"].ToString(),
                Salario = Math.Round(Convert.ToDecimal(reader["Salario"]), 2),
                DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                EhCasado = Convert.ToBoolean(reader["EhCasado"]),
                Genero = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader["Genero"].ToString())
            };
            return funcionario;
        }
    }
}
