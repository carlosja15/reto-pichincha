using Reto.Domain.Entities;

namespace Reto.Domain.Repositories;

public interface IClienteRepository
{
    Task<Cliente> Create(Cliente cliente);
    Task<Cliente> Update(int id, Cliente cliente);
    Task Delete(int id);
}
