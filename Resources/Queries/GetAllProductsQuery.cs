using MediatR;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Queries;
public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
}