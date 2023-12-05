namespace Dominio.Constantes
{
    public static class Excessoes
    {
        public const string NOME_NULO = "O campo Nome não pode ser nulo!";
        public const string NOME_CONTEM_CARACTERES_ESPECIAIS = "O campo Nome não pode conter caracteres especiais ou números!";
        public const string TAMANHO_NOME_INCOMPATIVEL = "O campo Nome deve conter pelo menos três caracteres!";
        public const string TAMANHO_MAX_NOME_INCOMPATIVEL = "O campo Nome não pode ter mais de 255 caracteres!";
        public const string CPF_PREENCHIDO_INCORRETAMENTE = "O campo CPF deve ser preenchido corretamente!";
        public const string TELEFONE_PREENCHIDO_INCORRETAMENTE = "O campo Telefone deve ser preenchido corretamente!";
        public const string SALARIO_NULO = "O campo Salário não pode ser nulo!";
        public const string NUMERO_INCORRETO_DE_CASAS_DECIMAIS = "O campo Salário deve conter duas casas decimais após a vírgula!";
        public const string IDADE_INVALIDA = "O funcionário não pode ter menos de 18 anos!";
        public const string QUANTIDADE_DE_VIRGULAS_INVALIDAS = "O campo Salário não pode ter mais de uma virgula!";
        public const string SALARIO_CONTEM_CARACTERES_ESPECIAIS = "O campo Salário não pode conter caracteres especiais ou letras!";
        public const string VALOR_DO_SALARIO_MUITO_ALTO = "O campo Salário não pode ser maior que 9.999.999.999,99!";
        public const string SALARIO_INVALIDO = "O valor contido no campo Salário é inválido!";
        public const string ERRO_AO_CADASTRAR_FUNCIONARIO = "Houve um erro ao tentar cadastrar um novo funcionário, tente novamente!";
        public const string ERRO_AO_PESQUISAR_FUNCIONARIO = "Houve um erro ao tentar pesquisar um funcionário no banco de dados, tente novamente!";
        public const string ERRO_AO_RECUPERAR_DADOS_DO_BANCO_DE_DADOS = "Houve um erro ao tentar recuperar as informações do banco de dados, tente novamente!";
        public const string ERRO_AO_ALTERAR_FUNCIONARIO = "Houve um erro ao tentar alterar os dados do funcionário, tente novamente!";
        public const string ERRO_AO_REMOVER_FUNCIONARIO = "Houve um erro ao tentar remover o cadastro selecionado, tente novamente!";
    }
}
