using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;
using Reto.Domain.Exceptions;
using Reto.Domain.Repositories;

namespace Reto.Infrastructure.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> Create(Cliente cliente)
    {
        var coincidences = await _context
            .Clientes
            .Where(x => x.Identificacion == cliente.Identificacion && x.Estado == true)
            .ToListAsync();

        if (coincidences.Any())
        {
            throw new ExistingRecordException(typeof(Cliente).Name, nameof(cliente.Identificacion), cliente.Identificacion);
        }

        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task<Cliente> Update(int id, Cliente cliente)
    {
        var entity = await _context.Clientes.FindAsync(id);

        if (entity is null)
        {
            throw new RecordNotFoundException(typeof(Cliente).Name, id);
        }

        var coincidences = await _context
            .Clientes
            .Where(x => x.Identificacion == cliente.Identificacion && x.Estado == true && x.Id == id)
            .ToListAsync();

        if (coincidences.Any())
        {
            throw new ExistingRecordException(typeof(Cliente).Name, nameof(cliente.Identificacion), cliente.Identificacion);
        }

        entity.Nombre = cliente.Nombre;
        entity.Edad = cliente.Edad;
        entity.Genero = cliente.Genero;
        entity.Identificacion = cliente.Identificacion;
        entity.Direccion = cliente.Direccion;
        entity.Telefono = cliente.Telefono;
        entity.Contrasenia = cliente.Contrasenia;

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Clientes.FindAsync(id);

        if (entity is null)
        {
            throw new RecordNotFoundException(typeof(Cliente).Name, id);
        }

        entity.Estado = false;

        await _context.SaveChangesAsync();
    }
}
