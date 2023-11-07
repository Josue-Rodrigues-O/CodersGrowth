using ControleFuncionarios.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFuncionarios
{
    public partial class CadastroFuncionario : Form
    {
        Validacoes validacao = new();
        public CadastroFuncionario()
        {
            InitializeComponent();
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
        }

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            LerEntradasDoUsuario();
        }

        private void Ao_Clicar_Em_Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LerEntradasDoUsuario()
        {
            Funcionario funcionario = new();
            try
            {
                if (validacao.ValidarNome(TxtNome.Text))
                {
                    funcionario.Nome = TxtNome.Text;
                }
                if (validacao.ValidarCpf(TxtCpf))
                {
                    funcionario.Cpf = TxtCpf.Text;
                }
                if (validacao.ValidarTelefone(TxtTelefone))
                {
                    funcionario.Telefone = TxtTelefone.Text;
                }
                if (validacao.ValidarSalario(TxtSalario.Text))
                {
                    funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
                }
                if (validacao.ValidarData(Calendario))
                {
                    funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
                }
                funcionario.EhCasado = RadCasado.Checked;
                funcionario.Genero = (GeneroEnum)ComboGenero.SelectedItem;
                TelaPrincipal.AtualizarLista(funcionario);
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        #region Validar Nome
        private bool NomeValido = true;
        private void TxtNome_KeyDown(object sender, KeyEventArgs e)
        {
            int aA = 65;
            int zZ = 90;
            int cedilha = 186;
            if (e.KeyValue >= aA && e.KeyValue <= zZ
                || e.KeyValue == (int)Keys.Back
                || e.KeyValue == (int)Keys.Space
                || e.KeyValue == cedilha)
            {
                NomeValido = true;
            }
            else
            {
                NomeValido = false;
            }
        }

        private void TxtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !NomeValido;
        }
        #endregion

        #region Validar Salario
        private bool SalarioValido = true;
        private void TxtSalario_KeyDown(object sender, KeyEventArgs e)
        {
            int virgula = 188;
            int zero = 48;
            int nove = 57;
            int NumZero = 96;
            int NumNove = 105;
            int NumVirgula = 110;
            if (e.KeyValue >= zero && e.KeyValue <= nove 
                || e.KeyValue >= NumZero && e.KeyValue <= NumNove
                || e.KeyValue == virgula
                || e.KeyValue == NumVirgula
                || e.KeyValue == (int)Keys.Back)
            {
                SalarioValido = true;
            }
            else
            {
                SalarioValido = false;
            }
        }

        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !SalarioValido;
        }
        #endregion
    }
}