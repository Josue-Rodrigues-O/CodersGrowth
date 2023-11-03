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
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            string StrEstadoCivil = tableLayoutEstadoCivil.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            switch (StrEstadoCivil)
            {
                case "Casado(a)": funcionario.EhCasado = true; break;
                case "Solteiro(a)": funcionario.EhCasado = false; break;
            }

            funcionario.Nome = TxtNome.Text;
            funcionario.Cpf = TxtCpf.Text;
            funcionario.Telefone = TxtTelefone.Text;
            funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
            funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
            TelaPrincipal.Lista(funcionario);
            this.Dispose();
        }
    }
}
