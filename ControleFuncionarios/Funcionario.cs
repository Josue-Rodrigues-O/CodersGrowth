using System;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public bool EhCasado { get; set; }
    public DateTime DataNascimento { get; set; }
    public Sexo Genero { get; set; }
    public enum Sexo
    {
        Masculino,
        Feminino
    }
}
