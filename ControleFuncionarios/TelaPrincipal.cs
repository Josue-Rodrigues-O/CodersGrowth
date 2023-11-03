using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();
        public TelaPrincipal()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            InitializeComponent();
        }
        public static void Lista(Funcionario funcionario)
        {
            TelaPrincipal.funcionarios.Add(funcionario);
            TelaListagem.DataSource = funcionarios;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadastroFuncionario frm2 = new CadastroFuncionario();
            frm2.Show();
        }
    }
}