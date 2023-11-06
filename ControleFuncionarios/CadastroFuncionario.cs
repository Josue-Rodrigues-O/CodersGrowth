using ControleFuncionarios.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            TelaPrincipal.AtualizarLista(LerEntradasDoUsuario());
            this.Close();
        }

        private void Ao_Clicar_Em_Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private Funcionario LerEntradasDoUsuario()
        {
            //Essalinha remove numeros e hifen - observar
            MessageBox.Show(Regex.Replace(TxtNome.Text, "[0-9-!@#$%&*+_?:;.,\\|/°\"'()]", String.Empty));

            return (new Funcionario
            {
                EhCasado = RadCasado.Checked,
                Nome = TxtNome.Text,
                Cpf = TxtCpf.Text,
                Telefone = TxtTelefone.Text,
                Salario = Convert.ToDecimal(TxtSalario.Text.ToString().Trim(new char[] { 'R', '$', ' ' })),
                DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString()),
                Genero = (GeneroEnum)ComboGenero.SelectedItem
            });
        }
    }
}

