using System;

public class Funcionario
{
	public enum Sexo : byte
	{
		Masculino = 0,
		Feminino = 1
	}
    public DateTime DataNascimento { get; set; }
    public string Nome { get; set; }
	public double Salario { get; set;}
	public bool EhCasado { get; set; }
	public string Cpf { get; set; }
	public int Id { get; set; }
}
