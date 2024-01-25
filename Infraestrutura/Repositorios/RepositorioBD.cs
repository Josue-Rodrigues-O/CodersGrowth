using Dominio;
using Dominio.Constantes;
using Dominio.Enums;
using LinqToDB.SqlQuery;
using Microsoft.Data.SqlClient;

namespace Infraestrutura.Repositorios
{
    public class RepositorioBD : IRepositorio
    {
        private const string NomeDaConexao = "ConexaoBD";
        private static readonly string connectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings[NomeDaConexao]
            .ConnectionString;
        private static SqlConnection Connection()
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            return connection;
        }
        private static Funcionario NovoFuncionario(SqlDataReader reader)
        {
            return new Funcionario
            {
                Id = Convert.ToInt32(reader[CamposTabelaBD.COLUNA_ID]),
                Nome = reader[CamposTabelaBD.COLUNA_NOME].ToString(),
                Cpf = reader[CamposTabelaBD.COLUNA_CPF].ToString(),
                Telefone = reader[CamposTabelaBD.COLUNA_TELEFONE].ToString(),
                Salario = Convert.ToDecimal(reader[CamposTabelaBD.COLUNA_SALARIO]),
                DataNascimento = Convert.ToDateTime(reader[CamposTabelaBD.COLUNA_DATA_NASCIMENTO]),
                EhCasado = Convert.ToBoolean(reader[CamposTabelaBD.COLUNA_EHCASADO]),
                Genero = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader[CamposTabelaBD.COLUNA_GENERO].ToString())
            };
        }
        public void Criar(Funcionario funcionario)
        {
            try
            {
                string query = $@"INSERT INTO {CamposTabelaBD.NOME_DA_TABELA} (
                                    {CamposTabelaBD.COLUNA_NOME},
                                    {CamposTabelaBD.COLUNA_CPF},
                                    {CamposTabelaBD.COLUNA_TELEFONE},
                                    {CamposTabelaBD.COLUNA_SALARIO},
                                    {CamposTabelaBD.COLUNA_DATA_NASCIMENTO},
                                    {CamposTabelaBD.COLUNA_EHCASADO},
                                    {CamposTabelaBD.COLUNA_GENERO}
                                ) 
                                VALUES (
                                    '{funcionario.Nome}',
                                    '{funcionario.Cpf}',
                                    '{funcionario.Telefone}',
                                    {funcionario.Salario.ToString().Replace(",", ".")},
                                    '{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                    {Convert.ToByte(funcionario.EhCasado)},
                                    '{funcionario.Genero}'
                                ); SELECT SCOPE_IDENTITY()";
                using var conn = Connection();
                SqlCommand cmd = new(query, conn);
                funcionario.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
                Funcionario funcionario = new();
                string query = $"SELECT * FROM {CamposTabelaBD.NOME_DA_TABELA} WHERE {CamposTabelaBD.COLUNA_ID}={id}";
                using (var conn = Connection())
                {
                    SqlCommand cmd = new(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        funcionario = NovoFuncionario(reader);
                    }
                }
                if (funcionario.Id == uint.MinValue)
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
                string query = $"SELECT * FROM {CamposTabelaBD.NOME_DA_TABELA}";
                List<Funcionario> lista = new();
                using (var conn = Connection())
                {
                    SqlCommand cmd = new(query, conn);
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
                string query = $@"UPDATE {CamposTabelaBD.NOME_DA_TABELA} SET 
                                {CamposTabelaBD.COLUNA_NOME} = '{funcionario.Nome}',
                                {CamposTabelaBD.COLUNA_CPF} = '{funcionario.Cpf}',
                                {CamposTabelaBD.COLUNA_TELEFONE} = '{funcionario.Telefone}',
                                {CamposTabelaBD.COLUNA_SALARIO} = {funcionario.Salario.ToString().Replace(",", ".")},
                                {CamposTabelaBD.COLUNA_DATA_NASCIMENTO} = '{funcionario.DataNascimento.Date:yyyy-MM-dd}',
                                {CamposTabelaBD.COLUNA_EHCASADO} = {Convert.ToByte(funcionario.EhCasado)},
                                {CamposTabelaBD.COLUNA_GENERO} = '{funcionario.Genero}' 
                                WHERE {CamposTabelaBD.COLUNA_ID} = {funcionario.Id}";

                using (var conn = Connection())
                {
                    SqlCommand cmd = new(query, conn);
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
                string query = $@"DELETE FROM {CamposTabelaBD.NOME_DA_TABELA} 
                                WHERE {CamposTabelaBD.COLUNA_ID} = {funcionario.Id}";
                using var conn = Connection();
                SqlCommand cmd = new(query, conn);
                cmd.ExecuteReader();
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_REMOVER_FUNCIONARIO);
            }
        }
    }
}
