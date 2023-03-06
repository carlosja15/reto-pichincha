namespace Reto.Application.Contracts.Cliente;

public class GetClientesResult
{
    public int ClienteId { get; set; }
    public string Nombre { get; set; } = default!;
}
