namespace Inventory.UnitTests
{
    public class AddProductDtoBuilder
    {
        private AddProductDto dto = new AddProductDto {
            Name = "dummy_name",
            No = "dummy_no",
            Price = 1000, 
            NumberOf = 10 
            ,Logo="dummy_logo"};


        public AddProductDtoBuilder WithName(string name)
        {
            dto.Name = name;
            return this;
        }


        public AddProductDtoBuilder WithNo(string no)
        {
            dto.No = no;
            return this;
        }

        public AddProductDtoBuilder WithPrice(int price)
        {
            dto.Price = price;
            return this;
        }
        public AddProductDtoBuilder WithNumberOf(int numberOf)
        {
            dto.NumberOf = numberOf;
            return this;
        }
        public AddProductDto Build()
        {
            return dto;
        }
    }
}