namespace Shoppy.App
{
    using System;

    public interface IShoppyBasketService
    {
        ShoppyBasket GetBasket(Guid id);
    }
}
