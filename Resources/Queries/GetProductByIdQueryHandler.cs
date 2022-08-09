using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ProductDBContext _context;
    public GetProductByIdQueryHandler(ProductDBContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
}
