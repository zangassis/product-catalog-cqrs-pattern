using MediatR;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Queries;
public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}