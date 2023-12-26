using MediatR;

namespace Catalog.Application.Commands;

public class DeleteProductCommand(string id) : IRequest<bool>
{
    public string Id { get; set; } = id;
}