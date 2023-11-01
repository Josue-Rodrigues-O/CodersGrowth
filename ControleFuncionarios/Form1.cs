using System.Globalization;

namespace ControleFuncionarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            InitializeComponent();
            AtualizarGrid();
            dataGrid.ReadOnly = true;
        }

        private List<Funcionario> Lista()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            funcionarios.Add(new Funcionario()
            {
                Id = 1,
                Nome = "AAAA",
                Cpf = "000.000.000-00",
                Telefone = "(00) 0 0000-0000",
                Salario = 1000.50M,
                EhCasado = true,
                DataNascimento = new DateTime(2003, 10, 12),
                genero = Funcionario.Sexo.Feminino,
            });

            funcionarios.Add(new Funcionario()
            {
                Id = 2,
                Nome = "antonio",
                Cpf = "111.111.111-111",
                Telefone = "(11) 1 1111-1111",
                Salario = 2000.00M,
                EhCasado = false,
                DataNascimento = new DateTime(1998, 05, 09),
                genero = Funcionario.Sexo.Masculino
            });

            return funcionarios;
        }

        private void AtualizarGrid()
        {
            dataGrid.DataSource = Lista();
        }
    }
}