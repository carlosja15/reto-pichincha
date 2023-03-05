using MediatR;
using Reto.Application.Contracts.Cliente;

namespace Reto.Application.Core.Cliente.Queries;

public record GetClientesQuery : IRequest<GetClientesResult>;
