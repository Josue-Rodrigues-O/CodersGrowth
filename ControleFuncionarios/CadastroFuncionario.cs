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
            return (new Funcionario
            {
                EhCasado = RadCasado.Checked,
                Nome = TxtNome.Text,
                Cpf = TxtCpf.Text,
                Telefone = TxtTelefone.Text,
                Salario = Convert.ToDecimal(TxtSalario.Text),
                DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString()),
                Genero = (GeneroEnum)ComboGenero.SelectedItem
            });
        }
    }
}

