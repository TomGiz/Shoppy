namespace Shoppy.App.Os
{
    using System.Collections.Generic;

    public sealed class BasketService<TBasket, TBasketLine> : IBasketService<TBasket, TBasketLine>
        where TBasket : Basket<TBasketLine>, new()
        where TBasketLine : BasketLine, new()
    {
        public TBasket GetBasket(BasketId id)
        {
            // hardcoded basket
            var basket = new TBasket();
            basket.Id = id;
            basket.BasketLines = new List<TBasketLine>
            {
                new TBasketLine
                {
                    Id = new BasketLineId { Value = 1001 },
                    ProductId = new ProductId(1),
                    Quantity = 5,
                    LineAmount = (5 * 999.99m).Euros()
                },
                new TBasketLine
                {
                    Id = new BasketLineId { Value = 1002 },
                    ProductId = new ProductId(12),
                    Quantity = 2,
                    LineAmount = (2 * 0.50m).Euros()
                }
            };

            return basket;
        }
    }
}
