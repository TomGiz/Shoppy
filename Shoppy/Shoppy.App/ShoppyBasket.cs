namespace Shoppy.App
{
    using Shoppy.App.Os;

    public class ShoppyBasket : Basket<ShoppyBasketLine>
    {
        public DeliverySlot ChosenDeliverySlot { get; set; }
    }
}