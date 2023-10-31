using System;

public class Funcionario
{
	private DateTime _DataNascimento;
	private string _Nome;
	private double _Salario;
	private bool _EhCasado;
	private string _Cpf;
	private enum _Sexo : byte
	{
		Masculino = 0,
		Feminino = 1
	}

    #region Acessores
	public DateTime DataNascimento
	{
		get { return _DataNascimento; }
		set { _DataNascimento = value; }
	}
	public string Nome
	{
		get { return _Nome; }
		set { _Nome = value; }
	}
	public double Salario
	{
		get { return _Salario; }
		set { _Salario = value; }
	}
	public bool EhCasado
	{
		get { return _EhCasado; }
		set { _EhCasado = value; }
	}
	public string Cpf
	{
		get { return _Cpf; }
		set { _Cpf = value; }
	}
    #endregion
}
