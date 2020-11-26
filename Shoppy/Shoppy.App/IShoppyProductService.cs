namespace Shoppy.App
{
    using Shoppy.App.Os;

    /// <summary>
    /// Dit zorgt voor een shorthand notatie die handig is bij injectie.
    /// </summary>
    public interface IShoppyProductService : IProductService<ShoppyProduct>
    {

    }
}