using Dominio;
using Dominio.Constantes;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceUsuarioSAPUI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public FuncionarioController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Funcionario funcionario)
        {
            try
            {
                Validacoes validacoes = new();
                if (funcionario == null) { throw new Exception(message: Excessoes.OBJETO_NULO); }
                validacoes.ValidarCampos(funcionario.Nome, funcionario.Cpf, funcionario.Telefone, funcionario.Salario.ToString(), funcionario.DataNascimento, (int)funcionario.Genero);
                _repositorio.Criar(funcionario);
                return Created(funcionario.Id.ToString(), funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? condicao)
        {
            try
            {
                IEnumerable<Funcionario> listaFiltrada;

                if (string.IsNullOrEmpty(condicao))
                {
                    listaFiltrada = _repositorio.ObterTodos();
                }
                else
                {
                    listaFiltrada =
                    from funcionario
                    in _repositorio.ObterTodos()
                    where funcionario.Nome.Contains(condicao, StringComparison.OrdinalIgnoreCase)
                    || funcionario.Cpf.Contains(condicao, StringComparison.OrdinalIgnoreCase)
                    select funcionario;
                }
                return Ok(listaFiltrada);
            }
            catch
            {
                return BadRequest(Excessoes.ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(uint id)
        {
            try
            {
                var funcionario = _repositorio.ObterPorId(id);
                if (funcionario is null) throw new Exception(message: Excessoes.ID_NULO);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null) { throw new Exception(message: Excessoes.OBJETO_NULO); }
                Validacoes validacoes = new();
                validacoes.ValidarCampos(funcionario.Nome, funcionario.Cpf, funcionario.Telefone, funcionario.Salario.ToString(), funcionario.DataNascimento, (int)funcionario.Genero);
                _repositorio.Atualizar(funcionario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(uint id)
        {
            try
            {
                var funcionario = _repositorio.ObterPorId(id);
                if (funcionario is null) throw new Exception(message: Excessoes.ID_NULO);
                _repositorio.Remover(funcionario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
