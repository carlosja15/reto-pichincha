using Reto.Domain.Entities;
using Reto.Domain.Exceptions;
using Reto.Domain.Repositories;

namespace Reto.Infrastructure.Persistence.Repositories;

public class MovimientoRepository : IMovimientoRepository
{
    private readonly AppDbContext _context;

    public MovimientoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Movimiento> Create(Movimiento movimiento)
    {
        await _context.Movimientos.AddAsync(movimiento);
        await _context.SaveChangesAsync();

        return movimiento;
    }

    public async Task<Movimiento> Update(int id, Movimiento movimiento)
    {
        var entity = await _context.Movimientos.FindAsync(id);

        if (entity is null)
        {
            throw new RecordNotFoundException(typeof(Movimiento).Name, id);
        }

        entity.Valor = movimiento.Valor;
        entity.Saldo = movimiento.Saldo;

        await _context.SaveChangesAsync();

        return entity;
    }
}
