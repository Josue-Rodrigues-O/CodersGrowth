namespace ControleFuncionarios
{
    internal class Repositorio : IRepositorio
    {
        protected List<Funcionario> ListaFuncionarios = Singleton.ListaFuncionario();

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
                MessageBox.Show("Funcionário removido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação cancelada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            var indice = ListaFuncionarios.FindIndex(func => func.Id == funcionario.Id);
            ListaFuncionarios[indice] = funcionario;
        }
    }
}
