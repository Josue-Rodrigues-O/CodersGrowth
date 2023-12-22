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
                using (var conn = Conexao())
                {
                    return conn.GetTable<Funcionario>().FirstOrDefault(x => x.Id == id);
                }
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

        public List<Funcionario> Filtrar(string condicao)
        {
            try
            {
                using (var conn = Conexao())
                {
                    var lista = conn.GetTable<Funcionario>().ToList();
                    var listaFiltrada = new List<Funcionario>();

                    listaFiltrada = lista.

                    foreach (var item in lista)
                    {
                        string ehCasado = string.Empty;
                        switch (item.EhCasado)
                        {
                            case true: ehCasado = "sim"; break;
                            case false: ehCasado = "nao"; break;
                        }

                        if (item.Id.ToString().Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.Nome.Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.Cpf.Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.Telefone.Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.Salario.ToString().Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.DataNascimento.ToString().Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (item.Genero.ToString().Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else if (ehCasado.Contains(condicao, StringComparison.OrdinalIgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                    }


                    return listaFiltrada;
                }
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS);
            }
        }
    }
}
