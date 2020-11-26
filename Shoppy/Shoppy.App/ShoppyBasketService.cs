namespace Shoppy.App
{
    using System;
    using Shoppy.App.Os;

    // TODO hackish or convenience?
    using IBasketService = Shoppy.App.Os.IBasketService<ShoppyBasket, ShoppyBasketLine>;

    public class ShoppyBasketService : IShoppyBasketService
    {
        private readonly IBasketService basketService;

        private readonly IDeliveryPlanningService planningService;

        private readonly IShoppyProductService productService;

        public ShoppyBasketService(
            IBasketService basketService,
            IDeliveryPlanningService planningService,
            IShoppyProductService productService)
        {
            this.basketService = basketService;
            this.planningService = planningService;
            this.productService = productService;
        }

        /// <inheritdoc />
        public ShoppyBasket GetBasket(Guid id)
        {
            var basketId = new BasketId(id);
            var basket = this.basketService.GetBasket(basketId);
            basket.ChosenDeliverySlot = this.planningService.GetChosenDeliverySlot(basketId);
            foreach (var line in basket.BasketLines)
            {
                // e.g. line.Comment from MiscXML
                line.Product = this.productService.GetProduct(line.ProductId.Value);
            }

            return basket;
        }
    }
}
