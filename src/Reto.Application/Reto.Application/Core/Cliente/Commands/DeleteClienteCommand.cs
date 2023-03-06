using MediatR;

namespace Reto.Application.Core.Cliente.Commands;

public class DeleteClienteCommand : IRequest
{
    public int Id { get; set; }

	public DeleteClienteCommand(int id)
	{
		Id = id;
	}
}
