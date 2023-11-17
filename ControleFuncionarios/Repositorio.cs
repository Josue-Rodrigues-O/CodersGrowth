using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios
{
    internal class Repositorio : IRepositorio
    {
        protected List<Funcionario> ListaFuncionarios = Singleton.listaFuncionario();
        
        public void Criar(Funcionario funcionario)
        {
            ListaFuncionarios.Add(funcionario);
        }

        public Funcionario ObterPorId(int id)
        {
            return ListaFuncionarios.Find(x => x.Id == id);
        }

        public List<Funcionario> ObterTodos()
        {
            return ListaFuncionarios;
        }

        public void Remover(Funcionario funcionario)
        {
            var remover = MessageBox.Show($"Deseja realmente remover o funcionário {funcionario.Nome} do banco de dados?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (remover.Equals(DialogResult.Yes))
            {
                ListaFuncionarios.Remove(funcionario);
            }
        }
    }
}
