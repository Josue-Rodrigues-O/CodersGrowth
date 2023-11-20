using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        private static readonly IRepositorio repositorio = new Repositorio();
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        public static void AtualizarDataGrid()
        {
            TelaListagem.DataSource = null;
            TelaListagem.DataSource = repositorio.ObterTodos(); 
        }

        private void Ao_Clicar_Em_Adicionar(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new();
            cadastro.ShowDialog();
        }

        private void Ao_Clicar_Em_Editar(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                Funcionario funcionario = repositorio.ObterPorId((int)TelaListagem.CurrentRow.Cells["ID"].Value);

                CadastroFuncionario cadastro = new(funcionario);
                cadastro.ShowDialog();
            }
        }

        private void Ao_Clicar_Em_Remover(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                Funcionario funcionario = repositorio.ObterPorId((int) TelaListagem.CurrentRow.Cells["ID"].Value);
                repositorio.Remover(funcionario);
                AtualizarDataGrid();
            }
        }
        private bool LinhaValida()
        {

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1 && Singleton.listaFuncionario().Any())
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
