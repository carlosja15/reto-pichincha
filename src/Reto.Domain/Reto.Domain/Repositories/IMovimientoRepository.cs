using Reto.Domain.Entities;

namespace Reto.Domain.Repositories;

public interface IMovimientoRepository
{
    Task<Movimiento> Create(Movimiento movimiento);
    Task<Movimiento> Update(int id, Movimiento movimiento);
}
