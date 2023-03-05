using MediatR;
using Reto.Application.Contracts.Cliente;
using Reto.Domain.Entities.Enums;

namespace Reto.Application.Core.Cliente.Commands;

public class CreateClienteCommand : IRequest<CreateClienteResult>
{
    public string Nombres { get; set; } = default!;
    public int Edad { get; set; }
    public GeneroPersona Genero { get; set; }
    public string Identificacion { get; set; } = default!;
    public string Direccion { get; set; } = default!;
    public string Telefono { get; set; } = default!;
    public string Contrasenia { get; set; } = default!;
}
