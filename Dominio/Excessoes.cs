namespace Dominio
{
    static class Excessoes
    {
        public const string NOME_NULO = "O campo Nome não pode ser nulo!";
        public const string NOME_CONTEM_CARACTERES_ESPECIAIS = "O campo Nome não pode conter caracteres especiais ou números!";
        public const string TAMANHO_NOME_INCOMPATIVEL = "O campo Nome deve conter pelo menos três caracteres!";
        public const string CPF_PREENCHIDO_INCORRETAMENTE = "O campo CPF deve ser preenchido corretamente!";
        public const string TELEFONE_PREENCHIDO_INCORRETAMENTE = "O campo Telefone deve ser preenchido corretamente!";
        public const string SALARIO_NULO = "O campo Salário não pode ser nulo!";
        public const string NUMERO_INCORRETO_DE_CASAS_DECIMAIS = "O campo Salário deve conter duas casas decimais após a vírgula!";
        public const string IDADE_INVALIDA = "O funcionário não pode ter menos de 18 anos!";
        public const string QUANTIDADE_DE_VIRGULAS_INVALIDAS = "O campo Salário não pode ter mais de uma virgula!";
        public const string SALARIO_CONTEM_CARACTERES_ESPECIAIS = "O campo Salário não pode conter caracteres especiais ou letras!";
        public const string VALOR_DO_SALARIO_MUITO_ALTO = "O campo Salário não pode ser maior que 9.999.999.999,99!";
    }
}
