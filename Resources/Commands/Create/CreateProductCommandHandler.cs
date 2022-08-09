using MediatR;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Commands.Create;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductDBContext _dbContext;

    public CreateProductCommandHandler(ProductDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category,
            Price = request.Price,
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}
