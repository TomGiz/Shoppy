namespace Shoppy.App.Os
{
    using System.Collections.Generic;

    public interface IBasketService<out TBasket, TBasketLine>
        where TBasket : Basket<TBasketLine>
        where TBasketLine : BasketLine
    {
        TBasket GetBasket(BasketId id);
    }

    public interface IProductService<out TProduct>
        where TProduct : Product
    {
        TProduct GetProduct(ProductId id);
    }

    public class ProductService<TProduct> : IProductService<TProduct>
        where TProduct : Product, new()
    {
        public TProduct GetProduct(ProductId id)
        {
            if (id.Value == 1 )
            {
                var product = new TProduct { Id = id, Brand = "Ouwsom", Description = "Het allerbeste item in onze shop", Price = new Money(Currency.Euro, 999.99m)};
                return product;
            }

            if (id.Value == 12)
            {
                var product = new TProduct { Id = id, Brand = "Whazaa", Description = "Het koopje van de week", Price = new Money(Currency.Euro, 0.50m) };
                return product;
            }

            return null;
        }
    }

    public class BasketService<TBasket, TBasketLine> : IBasketService<TBasket, TBasketLine>
        where TBasket : Basket<TBasketLine>, new()
        where TBasketLine: BasketLine, new()
    {
        public TBasket GetBasket(BasketId id)
        {
            // hardcoded basket
            var basket = new TBasket();
            basket.Id = id;
            basket.BasketLines = new List<TBasketLine>()
            {
                new TBasketLine()
                {
                    Id = new BasketLineId() { Value = 1001 }, ProductId = new ProductId() { Value = 1 }, Quantity = 5
                },
                new TBasketLine()
                {
                    Id = new BasketLineId() { Value = 1002 }, ProductId = new ProductId() { Value = 12 }, Quantity = 2
                }
            };

            return basket;
        }
    }
}
