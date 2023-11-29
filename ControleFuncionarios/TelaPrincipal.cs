using Infraestrutura;

namespace Interacao
{
    public partial class TelaPrincipal : Form
    {
        private static IRepositorio _repositorio;
        public TelaPrincipal(IRepositorio repositorio)
        {
            _repositorio = repositorio;
            InitializeComponent();
            AtualizarDataGrid();
        }
        public static void AtualizarDataGrid()
        {
            TelaListagem.DataSource = null;
            if (_repositorio.ObterTodos().Any())
                TelaListagem.DataSource = _repositorio.ObterTodos();
        }

        private void Ao_Clicar_Em_Adicionar(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new(_repositorio);
            cadastro.ShowDialog();
        }

        private void Ao_Clicar_Em_Editar(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                var funcionario = _repositorio.ObterPorId(ObterIdDaLinha());
                CadastroFuncionario cadastro = new(_repositorio, funcionario);
                cadastro.ShowDialog();
            }
        }

        private void Ao_Clicar_Em_Remover(object sender, EventArgs e)
        {
            if (LinhaValida())
            {
                var funcionario = _repositorio.ObterPorId(ObterIdDaLinha());

                var remover = MessageBox.Show($"Deseja realmente remover o funcionário {funcionario.Nome} do banco de dados?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (remover.Equals(DialogResult.Yes))
                {
                    _repositorio.Remover(funcionario);
                    AtualizarDataGrid();
                    MessageBox.Show("Funcionário removido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opereção cancelada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private static int ObterIdDaLinha()
        {
            return (int)TelaListagem.CurrentRow.Cells["ID"].Value;
        }
    }
}
