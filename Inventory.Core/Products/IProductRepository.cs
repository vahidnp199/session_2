using Inventory.Core.Products;

namespace Inventory.UnitTests
{
    public interface IProductRepository
    {
        void Add(Product product);
        Task Save(CancellationToken cancellationToken);
        Task<bool> IsExisByNo(string no);
    }
}