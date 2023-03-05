using Reto.Domain.Entities.Enums;
using Reto.Domain.Primitives;

namespace Reto.Domain.Entities;

public class Persona : Entity
{
    public string Nombre { get; set; } = default!;
    public GeneroPersona Genero { get; set; }
    public int Edad { get; set; }
    public string Identificacion { get; set; } = default!;
    public string Direccion { get; set; } = default!;
    public string Telefono { get; set; } = default!;
}
