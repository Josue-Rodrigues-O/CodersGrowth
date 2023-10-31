using System;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public double Salario { get; set; }
    public bool EhCasado { get; set; }
    public DateTime DataNascimento { get; set; }

    public enum Sexo : byte
	{
		Masculino = 0,
		Feminino = 1
	}
}
