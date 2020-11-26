namespace Shoppy.App
{
    using System.Collections.Generic;
    using Shoppy.App.Os;

    public interface IReviewService
    {
        IEnumerable<ProductReview> GetProductReview(ProductId productId);
    }
}