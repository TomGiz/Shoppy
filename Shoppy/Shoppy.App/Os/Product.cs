namespace Shoppy.App.Os
{
    public class Product
    {
        public ProductId Id { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public Money Price { get; set; }
    }
}
