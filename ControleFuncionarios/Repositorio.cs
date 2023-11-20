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
            }
        }

        public void Atualizar(Funcionario funcionarioEditado)
        {
            var indice = ListaFuncionarios.FindIndex(funcionario => funcionario.Id == funcionarioEditado.Id);
            ListaFuncionarios[indice] = funcionarioEditado;
        }
    }
}
