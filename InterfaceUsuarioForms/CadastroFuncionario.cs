using Dominio;
using Dominio.Constantes;
using Dominio.Enums;
using Infraestrutura.Repositorios;
using System.Text.RegularExpressions;

namespace InterfaceUsuarioForms
{
    public partial class CadastroFuncionario : Form
    {
        private readonly Funcionario _funcionario;
        private readonly IRepositorio _repositorio;
        public CadastroFuncionario(IRepositorio repositorio, Funcionario? funcionario = null)
        {
            int AnoMaximoDataNascimento = DateTime.Now.Year - (int)ValoresValidacao.IdadeMinima;
            InitializeComponent();
            _repositorio = repositorio;
            ComboGenero.DataSource = Enum.GetValues(typeof(GeneroEnum));
            Calendario.MaxDate = new DateTime(AnoMaximoDataNascimento, DateTime.Now.Month, DateTime.Now.Day);

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
            RadCasado.Checked = _funcionario.EhCasado;
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
            validacao.ValidarCampos(TxtNome.Text, TxtCpf.Text, TxtTelefone.Text, TxtSalario.Text, Calendario.SelectionStart, (int)ComboGenero.SelectedItem);
        }

        private void Ao_Clicar_Em_Salvar(object sender, EventArgs e)
        {
            try
            {
                ValidarEntradasDoUsuario();
                AtribuirValoresAoObjeto();
                if (_funcionario.Id == uint.MinValue)
                {
                    _repositorio.Criar(_funcionario);
                    MessageBox.Show(MensagensDoMessageBox.FUNCIONARIO_ADICIONADO, MensagensDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repositorio.Atualizar(_funcionario);
                    MessageBox.Show(MensagensDoMessageBox.FUNCIONARIO_ALTERADO, MensagensDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TelaPrincipal.AtualizarDataGrid();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MensagensDoMessageBox.ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ao_Clicar_Em_Cancelar(object sender, EventArgs e)
        {
            DialogResult cancelar;
            cancelar = MessageBox.Show(MensagensDoMessageBox.CANCELAR_OPERACAO, MensagensDoMessageBox.TEM_CERTEZA, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cancelar.Equals(DialogResult.Yes))
            {
                MessageBox.Show(MensagensDoMessageBox.CANCELADO_COM_SUCESSO, MensagensDoMessageBox.SUCESSO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void TxtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool EhBackspace = (int)e.KeyChar == (int)Keys.Back;
            bool EhEspaco = (int)e.KeyChar == (int)Keys.Space;
            bool EhDigitoValido = Regex.IsMatch(e.KeyChar.ToString(), ExpressoesRegex.REGEX_NOME);

            e.Handled = !(EhDigitoValido || EhBackspace || EhEspaco);
        }

        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Virgula = ',';
            const byte SegundoValorVetor = 1;
            bool CampoVazio = TxtSalario.Text.Length == uint.MinValue;
            bool PossuiVirgula = TxtSalario.Text.Contains(Virgula);
            bool EhDigitoValido = Regex.IsMatch(e.KeyChar.ToString(), ExpressoesRegex.REGEX_SALARIO);
            bool EhBackspace = (int)e.KeyChar == (int)Keys.Back;
            bool EhVirgula = e.KeyChar.Equals(Virgula);
            bool PossuiDuasCasasDecimais = PossuiVirgula && TxtSalario.Text.Split(Virgula)[SegundoValorVetor].Length == (int)ValoresValidacao.QuantidadeCasasDecimaisSalario;

            e.Handled = !(
                !(PossuiVirgula && EhVirgula)
                && EhDigitoValido
                && !(PossuiVirgula && PossuiDuasCasasDecimais)
                && !(CampoVazio && EhVirgula)
                || EhBackspace);
        }
    }
}