
namespace Inventory.UnitTests
{
    public interface IProductService
    {
        Task Add(AddProductDto dto, CancellationToken cancellationToken);
    }
}