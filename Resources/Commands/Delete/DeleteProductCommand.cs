using MediatR;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Commands.Delete;
public class DeleteProductCommand : IRequest<Product>
{
    public int Id { get; set; }
}