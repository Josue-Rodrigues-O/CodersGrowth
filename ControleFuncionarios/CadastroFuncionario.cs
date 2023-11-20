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
        #region Variaveis e Objetos
        private readonly Funcionario funcionario;
        private readonly IRepositorio repositorio = new Repositorio();
        #endregion
        public CadastroFuncionario(Funcionario? func = null)
        {
            InitializeComponent();
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
            Calendario.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);

            if (func != null)
            {
                funcionario = (Funcionario) func.ShallowCopy();
                Atribuir_Valores_Ao_Form();
            }
            else
            {
                funcionario = new();
            }
        }

        private void Atribuir_Valores_Ao_Form()
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

        private void Atribuir_Valores_Ao_Objeto()
        {
            funcionario.Nome = TxtNome.Text;
            funcionario.Cpf = TxtCpf.Text;
            funcionario.Telefone = TxtTelefone.Text;
            funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
            funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
            funcionario.EhCasado = RadCasado.Checked;
            funcionario.Genero = (GeneroEnum)ComboGenero.SelectedItem;
        }

        private void Validar_Entradas_Do_Usuario()
        {
            Validacoes validacao = new();
            validacao.Validar(TxtNome.Text, TxtCpf, TxtTelefone, TxtSalario.Text, Calendario);
        }

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            try
            {
                if (funcionario.Id == null)
                {
                    Validar_Entradas_Do_Usuario();
                    Atribuir_Valores_Ao_Objeto();
                    funcionario.Id = Singleton.IncrementarId();
                    repositorio.Criar(funcionario);
                    TelaPrincipal.AtualizarDataGrid();
                    MessageBox.Show("Funcionário adicionado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Validar_Entradas_Do_Usuario();
                    Atribuir_Valores_Ao_Objeto();
                    repositorio.Atualizar(funcionario);
                    TelaPrincipal.AtualizarDataGrid();
                    MessageBox.Show("Funcionário alterado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ao_Clicar_Em_Cancelar(object sender, EventArgs e)
        {
            DialogResult cancelar;
            cancelar = MessageBox.Show("Deseja mesmo cancelar a operação?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cancelar.Equals(DialogResult.Yes))
            {
                this.Close();
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