using Dominio;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterfaceUsuarioSAPUI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api : ControllerBase
    {
        private IRepositorio _repositorio = new Repositorio();

        // GET: api/<Api>
        [HttpGet]
        public List<Funcionario> Get()
        {
            return _repositorio.ObterTodos();
        }

        // GET api/<Api>/5
        [HttpGet("{id}")]
        public Funcionario Get(uint id)
        {
            return _repositorio.ObterPorId(id);
        }

        // POST api/<Api>
        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            if(funcionario == null) { return BadRequest("Deu Ruim"); }
            _repositorio.Criar(funcionario);
            return Created($"funcionario/{funcionario.Id}", funcionario);
        }

        // PUT api/<Api>/5
        [HttpPut("{id}")]
        public void Put(Funcionario funcionario)
        {
            _repositorio.Atualizar(funcionario);
        }

        // DELETE api/<Api>/5
        [HttpDelete("{id}")]
        public void Delete(Funcionario funcionario)
        {
            _repositorio.Remover(funcionario);
        }
    }
}
