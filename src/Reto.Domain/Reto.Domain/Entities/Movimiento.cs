using Reto.Domain.Entities.Enums;
using Reto.Domain.Primitives;

namespace Reto.Domain.Entities;

public class Movimiento : Entity
{
    public DateTime Fecha { get; set; }
    public TipoMovimiento Tipo { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
}
