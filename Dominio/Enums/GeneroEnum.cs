namespace Dominio.Enums
{
    public enum GeneroEnum
    {
        [LinqToDB.Mapping.MapValue(Value = "Indefinido")]
        Indefinido,
        [LinqToDB.Mapping.MapValue(Value = "Masculino")]
        Masculino,
        [LinqToDB.Mapping.MapValue(Value = "Feminino")]
        Feminino
    }
}
