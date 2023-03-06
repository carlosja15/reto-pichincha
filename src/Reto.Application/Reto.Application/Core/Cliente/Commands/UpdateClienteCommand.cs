using MediatR;
using Reto.Application.Contracts.Cliente;

namespace Reto.Application.Core.Cliente.Commands;

public class UpdateClienteCommand : CreateClienteCommand, IRequest<UpdateClienteResult>
{
    public int Id { get; set; }
}
