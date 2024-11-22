using BDD.Infrastructure.Persistence;
using DBB.Unit.Tests.Infrastructure;
using FluentAssertions;
using Inventory.Core.Products;

namespace Inventory.UnitTests
{
    public class ProductServiceTests : UnitTestPersistence<EFDataContext>
    {
        private readonly ProductService _productService;
        public ProductServiceTests()
        {
            _productService = CreateProductService();
        }
        [Fact]
        public async void Add_addes_product()
        {
            var dto = new AddProductDtoBuilder()
                .Build();

            await _productService.Add(dto, default);

            var product = ReadDataContext.Products.Single(_ => _.No == dto.No);
            product.Name.Should().Be(dto.Name);
            product.No.Should().Be(dto.No);
            product.Price.Should().Be(dto.Price);
            product.NumberOf.Should().Be(dto.NumberOf);
        }

        [Fact]
        public async void Add_throw_exception_when_product_no_is_duplicate()
        {
            var product = new Product
            {
                Name = "dummy_name",
                No = "dummy_no",
                Price = 1000,
                NumberOf = 10,
                Logo="dummy_logo"
            };
            Save(product);
            var dto = new AddProductDtoBuilder()
                .WithName(product.No)
                .Build();

            var expected = async () => await _productService.Add(dto, default);

            await expected.Should().ThrowAsync<ProductNoIsDuplicatedException>();
            ReadDataContext.Products.Should().HaveCount(1);

        }

        [Fact]
        public async void Add_throw_exception_when_product_price_smaller_1000()
        {
            var dto = new AddProductDtoBuilder()
                .WithName("dummy_name")
                .WithNumberOf(10)
                .WithPrice(999)
                .Build();

            var expected = async () => await _productService.Add(dto,default);

            await expected.Should().ThrowAsync<InvalidProductPriceException>();
        }


        private ProductService CreateProductService()
        {
            var productReposotry = new ProductRepository(Context);
            var productService = new ProductService(productReposotry);
            return productService;
        }

    }
}