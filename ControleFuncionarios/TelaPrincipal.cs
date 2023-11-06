using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();
        private static int ID = 0;
        public TelaPrincipal()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            InitializeComponent();
        }
        public static void Lista(Funcionario funcionario)
        {
            TelaListagem.DataSource = null;
            funcionario.Id = ID++;
            TelaPrincipal.funcionarios.Add(funcionario);
            TelaListagem.DataSource = funcionarios;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadastroFuncionario cadastro = new CadastroFuncionario();
            cadastro.Show();
        }
    }
}