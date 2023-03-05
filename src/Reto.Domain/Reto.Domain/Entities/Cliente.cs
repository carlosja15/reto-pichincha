using Reto.Domain.Entities.Enums;

namespace Reto.Domain.Entities;

public class Cliente : Persona
{
    public int ClienteId { get; set; }
    public string Contrasenia { get; set; } = default!;
    public bool Estado { get; set; }
    public ICollection<Cuenta> Cuentas { get; set; } = default!;

    public static Cliente Create(string nombre, int edad, GeneroPersona genero, string identificacion, string direccion, string telefono, string contrasenia)
    {

    }
}
