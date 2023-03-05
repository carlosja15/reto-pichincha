using Reto.Domain.Entities;

namespace Reto.Domain.Repositories;

public interface ICuentaRepository
{
    Task<Cuenta> Create(Cuenta cuenta);
    Task<Cuenta> Update(int id, Cuenta cuenta);
    Task Delete(int id);
}
