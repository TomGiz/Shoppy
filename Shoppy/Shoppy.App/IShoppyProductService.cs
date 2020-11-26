namespace Shoppy.App
{
    /// <summary>Dit zorgt voor een shorthand notatie die handig is bij injectie.</summary>
    public interface IShoppyProductService
    {
        ShoppyProduct GetProduct(int id);
    }
}
