using System;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public decimal Salario { get; set; }
    public bool EhCasado { get; set; }
    public DateTime DataNascimento { get; set; }
    public Sexo genero { get; set; }
    public enum Sexo
	{
		Masculino,
		Feminino
	}
}
