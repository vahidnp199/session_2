using BDD.Infrastructure.Persistence;
using Inventory.Core.Products;

namespace Inventory.UnitTests
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Add(AddProductDto dto, CancellationToken cancellationToken)
        {
            if (dto.Price < 1000)
                throw new InvalidProductPriceException();
            if (await productRepository.IsExisByNo(dto.No))
                throw new ProductNoIsDuplicatedException();

            var product = new Product
            {
                Price = dto.Price,
                Name = dto.Name,
                No = dto.No,
                NumberOf = dto.NumberOf,
                Logo = dto.Logo,
            };

            productRepository.Add(product);

            await productRepository.Save(cancellationToken);
        }
    }
}