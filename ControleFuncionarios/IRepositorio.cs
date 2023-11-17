using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    public interface IRepositorio
    {
        public List<Funcionario> ObterTodos();
        public Funcionario ObterPorId(int id);
        public void Criar(Funcionario funcionario);
        public void Remover(Funcionario funcionario);
    }
}
