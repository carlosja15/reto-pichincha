using MediatR;
using Reto.Domain.Repositories;

namespace Reto.Application.Core.Cliente.Commands;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        await _clienteRepository.Delete(request.Id);
    }
}
