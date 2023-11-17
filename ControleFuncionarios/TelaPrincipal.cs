using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        public static void AtualizarLista()
        {
            TelaListagem.DataSource = null;
            TelaListagem.DataSource = Singleton.listaFuncionario(); 
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
                remover = MessageBox.Show($"Deseja realmente remover o funcion�rio {funcionario.Nome} do banco de dados?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (remover.Equals(DialogResult.Yes))
                {
                    Singleton.listaFuncionario().Remove(funcionario);
                    AtualizarLista();
                }
            }
        }

        private Funcionario PegarFuncionario()
        {
            return Singleton.listaFuncionario().Find(x => x.Id == Convert.ToInt32(TelaListagem.CurrentRow.Cells["ID"].Value));
        }
        private bool LinhaValida()
        {

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1 && Singleton.listaFuncionario().Any())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Voc� deve selecionar uma linha!", "Aten��o!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
