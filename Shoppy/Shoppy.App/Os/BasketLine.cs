namespace Shoppy.App.Os
{
    public class BasketLine
    {
        public BasketLineId Id { get; set; }
        public ProductId ProductId { get; set; }

        public int Quantity { get; set; }

        public Money LineAmount { get; set; }
    }
}