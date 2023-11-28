namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        private static IRepositorio repositorio;
        public TelaPrincipal(IRepositorio repos)
        {
            repositorio = repos;
            InitializeComponent();
            AtualizarDataGrid();
        }
        public static void AtualizarDataGrid()
        {
            TelaListagem.DataSource = null;
            if (repositorio.ObterTodos().Any())
                TelaListagem.DataSource = repositorio.ObterTodos();
        }

        private void Ao_Clicar_Em_Adicionar(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new(repositorio);
            cadastro.ShowDialog();
        }

        private void Ao_Clicar_Em_Editar(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                Funcionario funcionario = repositorio.ObterPorId((int)TelaListagem.CurrentRow.Cells["ID"].Value);
                CadastroFuncionario cadastro = new(repositorio, funcionario);
                cadastro.ShowDialog();
            }
        }

        private void Ao_Clicar_Em_Remover(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                Funcionario funcionario = repositorio.ObterPorId((int)TelaListagem.CurrentRow.Cells["ID"].Value);
                repositorio.Remover(funcionario);
                AtualizarDataGrid();
            }
        }
        private static bool LinhaValida()
        {

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Você deve selecionar uma linha!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
