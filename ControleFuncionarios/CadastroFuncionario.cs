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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleFuncionarios
{
    public partial class CadastroFuncionario : Form
    {
        private readonly Funcionario funcionario;
        private static int IdTemp = 0;
        private readonly int IdNulo = 0;
        public CadastroFuncionario(Funcionario? func = null)
        {
            InitializeComponent();
            BtnCancelar.DialogResult = DialogResult.Cancel;
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
            Calendario.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);

            if (func != null)
            {
                funcionario = func;
                Atribuir_Valores();
            }
            else
            {
                funcionario = new();
            }
        }

        private void Atribuir_Valores()
        {
            TxtNome.Text = funcionario.Nome;
            TxtCpf.Text = funcionario.Cpf;
            TxtTelefone.Text = funcionario.Telefone;
            TxtSalario.Text = funcionario.Salario.ToString();
            if (funcionario.EhCasado)
            {
                RadCasado.Checked = true;
            }
            else
            {
                RadSolteiro.Checked = true;
            }
            ComboGenero.SelectedItem = funcionario.Genero;
            Calendario.SelectionStart = funcionario.DataNascimento;
        }

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            try
            {
                if (funcionario.Id == IdNulo)
                {
                    LerEntradasDoUsuario();
                    funcionario.Id = IncrementarId();
                    TelaPrincipal.ListaFuncionarios.Add(funcionario);
                    TelaPrincipal.AtualizarLista();
                    MessageBox.Show("Funcionário adicionado com sucesso!");
                }
                else
                {
                    LerEntradasDoUsuario();
                    TelaPrincipal.AtualizarLista();
                    MessageBox.Show("Funcionário alterado com sucesso!");
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LerEntradasDoUsuario()
        {
            Validacoes validacao = new();

            if (validacao.Validar(TxtNome.Text, TxtCpf, TxtTelefone, TxtSalario.Text, Calendario))
            {
                funcionario.Nome = TxtNome.Text;
                funcionario.Cpf = TxtCpf.Text;
                funcionario.Telefone = TxtTelefone.Text;
                funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
                funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
            }
            funcionario.EhCasado = RadCasado.Checked;
            funcionario.Genero = (GeneroEnum)ComboGenero.SelectedItem;
        }

        private static int IncrementarId()
        {
            IdTemp++;
            return IdTemp;
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