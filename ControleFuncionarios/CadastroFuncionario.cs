using ControleFuncionarios.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFuncionarios
{
    public partial class CadastroFuncionario : Form
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            funcionario.EhCasado = RadCasado.Checked;
            funcionario.Nome = TxtNome.Text;
            funcionario.Cpf = TxtCpf.Text;
            funcionario.Telefone = TxtTelefone.Text;
            funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
            funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
            funcionario.Genero = (GeneroEnum)ComboGenero.SelectedItem;

            TelaPrincipal.Lista(funcionario);
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
