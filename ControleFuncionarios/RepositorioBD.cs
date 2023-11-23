using ControleFuncionarios.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    public class RepositorioBD : IRepositorio
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public void Atualizar(Funcionario funcionarioEditado)
        {
            string nome = funcionarioEditado.Nome;
            string cpf = funcionarioEditado.Cpf;
            string telefone = funcionarioEditado.Telefone;
            DateTime datanascimento = funcionarioEditado.DataNascimento;
            byte ehcasado = Convert.ToByte(funcionarioEditado.EhCasado);
            string genero = funcionarioEditado.Genero.ToString();
            string salario = funcionarioEditado.Salario.ToString().Replace(",", ".");

            connection.Open();
            SqlCommand cmd = new($"UPDATE TabFuncionarios SET Nome='{nome}',Cpf='{cpf}',Telefone='{telefone}',Salario={salario},DataNascimento='{datanascimento.Date.ToString("yyyy-MM-dd")}',EhCasado={ehcasado},Genero='{genero}' WHERE Id={funcionarioEditado.Id}", connection);
            cmd.ExecuteReader();
            connection.Close();
        }

        public void Criar(Funcionario funcionario)
        {
            string nome = funcionario.Nome;
            string cpf = funcionario.Cpf;
            string telefone = funcionario.Telefone;
            DateTime datanascimento = funcionario.DataNascimento;
            byte ehcasado = Convert.ToByte(funcionario.EhCasado);
            string genero = funcionario.Genero.ToString();
            string salario = funcionario.Salario.ToString().Replace(",", ".");

            connection.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO TabFuncionarios (Nome,Cpf,Telefone,Salario,DataNascimento,EhCasado,Genero) VALUES ('{nome}','{cpf}','{telefone}',{salario},'{datanascimento.Date.ToString("yyyy-MM-dd")}',{ehcasado},'{genero}')", connection);
            cmd.ExecuteReader();
            connection.Close();
        }

        public Funcionario ObterPorId(int id)
        {
            Funcionario funcionario = new();
            connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from TabFuncionarios where Id={id}", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                funcionario.Id = Convert.ToInt32(reader["Id"]);
                funcionario.Nome = reader["Nome"].ToString();
                funcionario.Cpf = reader["Cpf"].ToString();
                funcionario.Telefone = reader["Telefone"].ToString();
                funcionario.Salario = Convert.ToDecimal(reader["Salario"]);
                funcionario.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                funcionario.EhCasado = Convert.ToBoolean(reader["EhCasado"]);
                funcionario.Genero = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader["Genero"].ToString());
            }
            connection.Close();
            return funcionario;
        }

        public List<Funcionario> ObterTodos()
        {
            List<Funcionario> lista = new();
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from TabFuncionarios", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Funcionario
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString(),
                    Cpf = reader["Cpf"].ToString(),
                    Telefone = reader["Telefone"].ToString(),
                    Salario = Math.Round(Convert.ToDecimal(reader["Salario"]), 2),
                    DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                    EhCasado = Convert.ToBoolean(reader["EhCasado"]),
                    Genero = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader["Genero"].ToString())
                });
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
                SqlCommand cmd = new SqlCommand($"DELETE from TabFuncionarios WHERE id={funcionario.Id}", connection);
                cmd.ExecuteReader();
                connection.Close();
            }
        }
    }
}
