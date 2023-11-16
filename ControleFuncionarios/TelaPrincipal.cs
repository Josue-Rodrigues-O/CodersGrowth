using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        static readonly Singleton singleton = Singleton.Instance;
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        public static void AtualizarLista()
        {
            TelaListagem.DataSource = null;
            TelaListagem.DataSource = singleton.ListaFuncionarios;
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
                CadastroFuncionario cadastro = new(PegarFuncionario());
                cadastro.ShowDialog();
            }
        }

        private void Ao_Clicar_Em_Remover(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                Funcionario funcionario = PegarFuncionario();
                DialogResult remover;
                remover = MessageBox.Show($"Deseja realmente remover o funcionário {funcionario.Nome} do banco de dados?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (remover.Equals(DialogResult.Yes))
                {
                    singleton.ListaFuncionarios.Remove(funcionario);
                    AtualizarLista();
                }
            }
        }

        private Funcionario PegarFuncionario()
        {
            return singleton.ListaFuncionarios.Find(x => x.Id == Convert.ToInt32(TelaListagem.CurrentRow.Cells["ID"].Value));
        }
        private bool LinhaValida()
        {

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1 && singleton.ListaFuncionarios.Any())
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
