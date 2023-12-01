using Infraestrutura;
using Interacao.Constantes;

namespace Interacao
{
    public partial class TelaPrincipal : Form
    {
        private const byte SoUmaLinha = 1;
        private static IRepositorio _repositorio;
        public TelaPrincipal(IRepositorio repositorio)
        {
            _repositorio = repositorio;
            InitializeComponent();
            AtualizarDataGrid();
        }
        public static void AtualizarDataGrid()
        {
            TelaListagem.DataSource = new();
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

                var remover = MessageBox.Show(MensagesDoMessageBox.DesejaRemoverFuncionario(funcionario), MensagesDoMessageBox.TEM_CERTEZA, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (remover.Equals(DialogResult.Yes))
                {
                    _repositorio.Remover(funcionario);
                    AtualizarDataGrid();
                    MessageBox.Show(MensagesDoMessageBox.FUNCIONARIO_REMOVIDO, MensagesDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(MensagesDoMessageBox.CANCELADO_COM_SUCESSO, MensagesDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private static bool LinhaValida()
        {

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) == SoUmaLinha)
            {
                return true;
            }
            else
            {
                MessageBox.Show(MensagesDoMessageBox.SELECIONE_UMA_LINHA, MensagesDoMessageBox.ATENCAO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private static uint ObterIdDaLinha()
        {
            return (uint)TelaListagem.CurrentRow.Cells["ID"].Value;
        }
    }
}
