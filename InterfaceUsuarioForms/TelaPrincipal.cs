using Infraestrutura.Repositorios;
using Dominio.Constantes;

namespace InterfaceUsuarioForms
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

                var remover = MessageBox.Show(MensagensDoMessageBox.DesejaRemoverFuncionario(funcionario), MensagensDoMessageBox.TEM_CERTEZA, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (remover.Equals(DialogResult.Yes))
                {
                    _repositorio.Remover(funcionario);
                    AtualizarDataGrid();
                    MessageBox.Show(MensagensDoMessageBox.FUNCIONARIO_REMOVIDO, MensagensDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private static bool LinhaValida()
        {
            const byte SoUmaLinha = 1;

            if (TelaListagem.Rows.GetRowCount(DataGridViewElementStates.Selected) != SoUmaLinha)
            {
                MessageBox.Show(MensagensDoMessageBox.SELECIONE_UMA_LINHA, MensagensDoMessageBox.ATENCAO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
           
            return true;
        }

        private static int ObterIdDaLinha()
        {
            const string colunaId = "ID";
            return (int)TelaListagem.CurrentRow.Cells[colunaId].Value;
        }
    }
}
