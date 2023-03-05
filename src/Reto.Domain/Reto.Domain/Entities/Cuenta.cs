using Reto.Domain.Primitives;

namespace Reto.Domain.Entities;

public class Cuenta : Entity
{
    public string NroCuenta { get; set; } = default!;
    public string TipoCuenta { get; set; } = default!;
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = default!;
}
