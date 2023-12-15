using Dominio;
using Dominio.Constantes;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceUsuarioSAPUI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCrud : ControllerBase
    {
        private readonly IRepositorio _repositorio = new Repositorio();

        [HttpGet]
        public List<Funcionario> ObterTodos()
        {
            try
            {
                return _repositorio.ObterTodos();
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS);
            }
        }

        [HttpGet("{id}")]
        public Funcionario ObterPorId(uint id)
        {
            try
            {
                if (id == uint.MinValue) throw new Exception(message: Excessoes.ID_NULO);
                return _repositorio.ObterPorId(id);
            }
            catch
            {
                throw new Exception(message: Excessoes.ERRO_AO_PESQUISAR_FUNCIONARIO);
            }
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Funcionario funcionario)
        {
            try
            {
                Validacoes validacoes = new();
                if (funcionario == null) { throw new Exception(message: Excessoes.OBJETO_NULO); }
                validacoes.ValidarCampos(funcionario.Nome, funcionario.Cpf, funcionario.Telefone, funcionario.Salario.ToString(), funcionario.DataNascimento);
                _repositorio.Criar(funcionario);
                return Created(Constantes.ROTA_CRIAR, funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        [HttpPatch]
        public OkObjectResult Atualizar([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null) { throw new Exception(message: Excessoes.OBJETO_NULO); }
                Validacoes validacoes = new();
                validacoes.ValidarCampos(funcionario.Nome, funcionario.Cpf, funcionario.Telefone, funcionario.Salario.ToString(), funcionario.DataNascimento);
                _repositorio.Atualizar(funcionario);
                return Ok(Constantes.SUCESSO);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public OkObjectResult Remover(uint id)
        {
            try
            {
                if (id == uint.MinValue) throw new Exception(message: Excessoes.ID_NULO);
                _repositorio.Remover(_repositorio.ObterPorId(id));
                return Ok(Constantes.SUCESSO);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
