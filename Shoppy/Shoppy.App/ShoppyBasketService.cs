namespace Shoppy.App
{
    using Shoppy.App.Os;

    public class ShoppyBasketService : IShoppyBasketService
    {
        private readonly IShoppyBasketService basketService;
        private readonly IDeliveryPlanningService planningService;
        private readonly IShoppyProductService productService;

        public ShoppyBasketService(IShoppyBasketService basketService, IDeliveryPlanningService planningService,
                                   IShoppyProductService productService)
        {
            this.basketService = basketService;
            this.planningService = planningService;
            this.productService = productService;
        }

        /// <inheritdoc />
        public ShoppyBasket GetBasket(BasketId id)
        {
            var basket = this.basketService.GetBasket(id);
            basket.ChosenDeliverySlot = this.planningService.GetChosenDeliverySlot(id);
            foreach (var line in basket.BasketLines)
            {
                // e.g. line.Comment from MiscXML
                line.Product = this.productService.GetProduct(line.ProductId);
            }

            return basket;
        }
    }
}
