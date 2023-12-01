using Dominio;
using Dominio.Enums;
using Infraestrutura;
using System.Text.RegularExpressions;

namespace Interacao
{
    public partial class CadastroFuncionario : Form
    {
        private readonly Funcionario _funcionario;
        private readonly IRepositorio _repositorio;
        public CadastroFuncionario(IRepositorio repositorio, Funcionario? funcionario = null)
        {
            InitializeComponent();
            _repositorio = repositorio;
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
            Calendario.MaxDate = new DateTime(DateTime.Now.Year - (int)ValoresValidacaoEnum.IdadeMinima, DateTime.Now.Month, DateTime.Now.Day);

            if (funcionario != null)
            {
                _funcionario = (Funcionario)funcionario.ShallowCopy();
                AtribuirValoresAoForm();
            }
            else
            {
                _funcionario = new();
            }
        }

        private void AtribuirValoresAoForm()
        {
            TxtNome.Text = _funcionario.Nome;
            TxtCpf.Text = _funcionario.Cpf;
            TxtTelefone.Text = _funcionario.Telefone;
            TxtSalario.Text = _funcionario.Salario.ToString();
            if (_funcionario.EhCasado)
            {
                RadCasado.Checked = true;
            }
            else
            {
                RadSolteiro.Checked = true;
            }
            ComboGenero.SelectedItem = _funcionario.Genero;
            Calendario.SelectionStart = _funcionario.DataNascimento;
        }

        private void AtribuirValoresAoObjeto()
        {
            _funcionario.Nome = TxtNome.Text;
            _funcionario.Cpf = TxtCpf.Text;
            _funcionario.Telefone = TxtTelefone.Text;
            _funcionario.Salario = Convert.ToDecimal(TxtSalario.Text);
            _funcionario.DataNascimento = Convert.ToDateTime(Calendario.SelectionStart.ToShortDateString());
            _funcionario.EhCasado = RadCasado.Checked;
            _funcionario.Genero = (GeneroEnum)ComboGenero.SelectedItem;
        }

        private void ValidarEntradasDoUsuario()
        {
            Validacoes validacao = new();
            validacao.ValidarCampos(TxtNome.Text, TxtCpf.Text, TxtTelefone.Text, TxtSalario.Text, Calendario.SelectionStart);
        }

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            try
            {
                if (_funcionario.Id == null)
                {
                    ValidarEntradasDoUsuario();
                    AtribuirValoresAoObjeto();
                    _funcionario.Id = Singleton.IncrementarId();
                    _repositorio.Criar(_funcionario);
                    TelaPrincipal.AtualizarDataGrid();
                    MessageBox.Show("Funcionário adicionado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ValidarEntradasDoUsuario();
                    AtribuirValoresAoObjeto();
                    _repositorio.Atualizar(_funcionario);
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
                MessageBox.Show("Operação cancelada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        #region Validar Nome
        private void TxtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]")
                || (int)e.KeyChar == (int)Keys.Back
                || (int)e.KeyChar == (int)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Validar Salario
        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            var PossuiVirgula = TxtSalario.Text.Contains(',');

            if ((Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") || (!PossuiVirgula && e.KeyChar.Equals(','))) 
                && !(PossuiVirgula && TxtSalario.Text.Split(',')[1].Length == (int)ValoresValidacaoEnum.QuantidadeDeVirgulaMax) 
                || (int)e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}