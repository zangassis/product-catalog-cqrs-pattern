using MediatR;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Commands.Delete;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly ProductDBContext _dbContext;

    public DeleteProductCommandHandler(ProductDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == request.Id);

        if (product is null)
            return default;

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}