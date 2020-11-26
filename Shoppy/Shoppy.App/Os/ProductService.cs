namespace Shoppy.App.Os
{
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
}
