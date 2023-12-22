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
                return _listaFuncionarios.FirstOrDefault(x => x.Id == id);
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

        public List<Funcionario> Filtrar(string condicao)
        {
            try
            {
                var listaFiltrada = new List<Funcionario>();
                foreach (var item in _listaFuncionarios)
                {
                    string ehCasado = string.Empty;
                    switch (item.EhCasado)
                    {
                        case true: ehCasado = "sim"; break;
                        case false: ehCasado = "nao"; break;
                    }

                    if (item.Id.ToString().Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.Nome.Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.Cpf.Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.Telefone.Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.Salario.ToString().Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.DataNascimento.ToString().Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (item.Genero.ToString().Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                    else if (ehCasado.Contains(condicao))
                    {
                        listaFiltrada.Add(item);
                    }
                }
                return listaFiltrada;
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS);
            }
        }
    }
}
