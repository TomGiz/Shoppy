namespace Shoppy.App.Os
{
    public interface IProductService<out TProduct>
        where TProduct : Product
    {
        TProduct GetProduct(ProductId id);
    }
}