using Reto.Domain.Entities.Enums;

namespace Reto.Domain.Entities;

public class Cliente : Persona
{
    public string Contrasenia { get; set; } = default!;
    public bool Estado { get; set; }
    public ICollection<Cuenta> Cuentas { get; set; } = default!;

    public static Cliente Create(string nombre, int edad, GeneroPersona genero, string identificacion, string direccion, string telefono, string contrasenia) => new()
    {
        Nombre = nombre,
        Edad = edad,
        Genero = genero,
        Identificacion = identificacion,
        Direccion = direccion,
        Telefono = telefono,
        Contrasenia = contrasenia,
        Estado = true
    };

    public static Cliente Update(string nombre, int edad, GeneroPersona genero, string identificacion, string direccion, string telefono, string contrasenia) => new()
    {
        Nombre = nombre,
        Edad = edad,
        Genero = genero,
        Identificacion = identificacion,
        Direccion = direccion,
        Telefono = telefono,
        Contrasenia = contrasenia
    };
}
