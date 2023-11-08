using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        private static readonly List<Funcionario> funcionarios = new();
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        public static void AtualizarLista(Funcionario funcionario)
        {
            TelaListagem.DataSource = null;
            TelaPrincipal.funcionarios.Add(funcionario);
            TelaListagem.DataSource = funcionarios;
        }
        private void Ao_Clicar_Em_Adicionar(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new();
            cadastro.Show();
        }
    }
}