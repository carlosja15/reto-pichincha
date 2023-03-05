namespace Reto.Domain.Exceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string entityType, object id)
        : base($"El registro de tipo {entityType} con ID {id} no fue encontrado en la base de datos.")
    {
        EntityType = entityType;
        Id = id;
    }

    public string EntityType { get; }
    public object Id { get; }
}
