namespace Shoppy.App
{
    using System.Collections.Generic;
    using Shoppy.App.Os;


    /// <summary>
    /// Dit zorgt voor een shorthand notatie die handig is bij injectie.
    /// </summary>
    public interface IShoppyBasketService : IBasketService<ShoppyBasket, ShoppyBasketLine>
    {
    }

    public interface IReviewService
    {
        IEnumerable<ProductReview> GetProductReview(ProductId productId);
    }

    public interface IDeliveryPlanningService
    {
        DeliverySlot GetChosenDeliverySlot(BasketId basketId);
    }

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

    /// <summary>
    /// Dit zorgt voor een shorthand notatie die handig is bij injectie.
    /// </summary>
    public interface IShoppyProductService : IProductService<ShoppyProduct>
    {

    }

    public class ShoppyProductService : IShoppyProductService
    {
        private readonly IShoppyProductService productService;
        private readonly IReviewService reviewService;

        public ShoppyProductService(IShoppyProductService productService, IReviewService reviewService)
        {
            this.productService = productService;
            this.reviewService = reviewService;
        }

        /// <inheritdoc />
        public ShoppyProduct GetProduct(ProductId id)
        {
            var product = this.productService.GetProduct(id);
            product.Reviews = this.reviewService.GetProductReview(id);
            return product;
        }
    }
}
