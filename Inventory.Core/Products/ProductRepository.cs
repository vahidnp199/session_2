using BDD.Infrastructure.Persistence;
using Inventory.Core.Products;
using Microsoft.EntityFrameworkCore;

namespace Inventory.UnitTests
{
    public class ProductRepository : IProductRepository
    {
        private EFDataContext context;

        public ProductRepository(EFDataContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public Task<bool> IsExisByNo(string no)
        {
            return context.Products.AnyAsync(p => p.No == no);
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}