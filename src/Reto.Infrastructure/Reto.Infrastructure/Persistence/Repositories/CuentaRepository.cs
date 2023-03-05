using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;
using Reto.Domain.Exceptions;
using Reto.Domain.Repositories;

namespace Reto.Infrastructure.Persistence.Repositories;

public class CuentaRepository : ICuentaRepository
{
    private readonly AppDbContext _context;

    public CuentaRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Cuenta> Create(Cuenta cuenta)
    {
        var coincidences = await _context.Cuentas.Where(x => x.NroCuenta == cuenta.NroCuenta && x.Estado == true).ToListAsync();

        if (coincidences.Any() )
        {
            throw new ExistingRecordException(typeof(Cuenta).Name, nameof(cuenta.NroCuenta), cuenta.NroCuenta);
        }

        await _context.Cuentas.AddAsync(cuenta);
        await _context.SaveChangesAsync();

        return cuenta;
    }

    public async Task<Cuenta> Update(int id, Cuenta cuenta)
    {
        var entity = await _context.Cuentas.FindAsync(id);

        if (entity is null)
        {
            throw new RecordNotFoundException(typeof(Cuenta).Name, id);
        }

        var coincidences = await _context
            .Cuentas
            .Where(x => x.NroCuenta == cuenta.NroCuenta && x.Estado == true && x.Id != id)
            .ToListAsync();

        if (coincidences.Any())
        {
            throw new ExistingRecordException(typeof(Cuenta).Name, nameof(cuenta.NroCuenta), cuenta.NroCuenta);
        }

        entity.NroCuenta = cuenta.NroCuenta;
        entity.TipoCuenta = cuenta.TipoCuenta;
        entity.SaldoInicial = cuenta.SaldoInicial;

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Cuentas.FindAsync(id);

        if (entity is null )
        {
            throw new RecordNotFoundException(typeof(Cuenta).Name, id);
        }

        entity.Estado = false;

        await _context.SaveChangesAsync();
    }
}
