using MediatR;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Resources.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ProductDBContext _dbContext;

        public UpdateProductCommandHandler(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == request.Id);

            if (product is null)
                return default;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Price = request.Price;

            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}