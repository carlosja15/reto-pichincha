using Reto.Domain.Entities.Enums;

namespace Reto.Application.Contracts.Cliente;

public class CreateClienteResult
{
    public int Id { get; set; }
    public string Nombres { get; set; } = default!;
    public int Edad { get; set; }
    public GeneroPersona Genero { get; set; }
    public string Identificacion { get; set; } = default!;
    public string Direccion { get; set; } = default!;
    public string Telefono { get; set; } = default!;
    public string Contrasenia { get; set; } = default!;
}
