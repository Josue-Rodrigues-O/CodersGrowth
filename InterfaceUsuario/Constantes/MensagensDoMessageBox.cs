using Dominio;

namespace InterfaceUsuario.Constantes
{
    public class MensagensDoMessageBox
    {
        public const string SELECIONE_UMA_LINHA = "Você deve selecionar uma linha!";
        public const string FUNCIONARIO_ADICIONADO = "Funcionário adicionado com sucesso!";
        public const string FUNCIONARIO_ALTERADO = "Funcionário alterado com sucesso!";
        public const string FUNCIONARIO_REMOVIDO = "Funcionário removido com sucesso!";
        public const string CANCELAR_OPERACAO = "Deseja mesmo cancelar a operação?";
        public const string CANCELADO_COM_SUCESSO = "Operação cancelada com sucesso!";
        public const string TEM_CERTEZA = "Tem certeza?";
        public const string SUCESSO = "Sucesso!";
        public const string ATENCAO = "Atenção!";
        public const string ERRO = "Erro!";

        public static string DesejaRemoverFuncionario(Funcionario funcionario)
        {
            return $"Deseja realmente remover o funcionário {funcionario.Nome} do banco de dados?";
        }
    }
}
