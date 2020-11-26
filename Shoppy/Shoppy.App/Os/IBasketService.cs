namespace Shoppy.App.Os
{
    public interface IBasketService<out TBasket, TBasketLine>
        where TBasket : Basket<TBasketLine>
        where TBasketLine : BasketLine
    {
        TBasket GetBasket(BasketId id);
    }
}