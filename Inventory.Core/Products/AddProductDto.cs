using System.Diagnostics;

namespace Inventory.UnitTests
{
    public class AddProductDto
    {
        public int Price { get; set; }
        public string No { get; set; } = default!;
        public int NumberOf { get; set; }
        public string Name
        {
            get; set;
        } = default!;
        public string Logo { get; set; } = default!;
    }
}