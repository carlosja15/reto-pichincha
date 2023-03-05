namespace Reto.Domain.Exceptions;

public class ExistingRecordException : Exception
{
    public ExistingRecordException(string entityType, string propertyName, object propertyValue)
        : base($"El registro de tipo {entityType} con la propiedad {propertyName} = {propertyValue} ya existe en la base de datos.")
    {
        EntityType = entityType;
        PropertyName = propertyName;
        PropertyValue = propertyValue;
    }

    public string EntityType { get; }
    public string PropertyName { get; }
    public object PropertyValue { get; }
}
