using System.Globalization;

namespace ControleFuncionarios
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            InitializeComponent();
            AtualizarGrid();
            TelaListagem.ReadOnly = true;
        }

        private List<Funcionario> Lista()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            funcionarios.Add(new Funcionario()
            {
                Id = 1,
                Nome = "Lucas",
                Cpf = "000.000.000-00",
                Telefone = "(00) 0 0000-0000",
                Salario = 1000.50M,
                EhCasado = true,
                DataNascimento = new DateTime(2003, 10, 12),
                Genero = Funcionario.Sexo.Feminino,
            });

            funcionarios.Add(new Funcionario()
            {
                Id = 2,
                Nome = "Antonio",
                Cpf = "111.111.111-111",
                Telefone = "(11) 1 1111-1111",
                Salario = 2000.00M,
                EhCasado = false,
                DataNascimento = new DateTime(1998, 05, 09),
                Genero = Funcionario.Sexo.Masculino
            });

            return funcionarios;
        }

        private void AtualizarGrid()
        {
            TelaListagem.DataSource = Lista();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadastroFuncionario frm2 = new CadastroFuncionario();
            frm2.Show();
        }
    }
}