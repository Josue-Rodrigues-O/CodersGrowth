using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        public static bool Editar = false;
        public static int ItemSelecionado;

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
            Editar = false;
            CadastroFuncionario cadastro = new();
            cadastro.Show();
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
                Editar = true;
                ItemSelecionado = Convert.ToInt32(TelaListagem.CurrentRow.Cells["ID"].Value);
                CadastroFuncionario cadastro = new();
                cadastro.Show();
            }
        }
    }
}