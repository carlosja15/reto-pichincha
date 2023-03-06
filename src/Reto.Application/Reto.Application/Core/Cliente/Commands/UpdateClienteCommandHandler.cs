using Mapster;
using MediatR;
using Reto.Application.Contracts.Cliente;
using Reto.Domain.Repositories;

namespace Reto.Application.Core.Cliente.Commands;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, UpdateClienteResult>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<UpdateClienteResult> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = Domain.Entities.Cliente.Update(
            request.Nombre,
            request.Edad,
            request.Genero,
            request.Identificacion,
            request.Direccion,
            request.Telefono,
            request.Contrasenia);

        var result = await _clienteRepository.Update(request.Id, cliente);

        return result.Adapt<UpdateClienteResult>();
    }
}
