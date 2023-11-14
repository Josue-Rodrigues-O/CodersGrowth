using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        public static readonly List<Funcionario> ListaFuncionarios = new();
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        public static void AtualizarLista()
        {
            TelaListagem.DataSource = null;
            TelaListagem.DataSource = ListaFuncionarios;
        }
        private void Ao_Clicar_Em_Adicionar(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new();
            cadastro.ShowDialog();
        }

        private void Ao_Clicar_Em_Editar(object sender, EventArgs e)
        {
            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1)
            {
                MessageBox.Show("Selecione só uma linha!");
            }
            else
            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1)
            {
                MessageBox.Show("Selecione pelo menos uma linha!");
            }
            else
            if (!ListaFuncionarios.Any())
            {
                MessageBox.Show("A lista está vazia!");
            }
            else
            {
                Funcionario funcionario = ListaFuncionarios.Find(x => x.Id == Convert.ToInt32(TelaListagem.CurrentRow.Cells["ID"].Value));
                CadastroFuncionario cadastro = new(funcionario);
                cadastro.ShowDialog();
            }
        }
    }
}