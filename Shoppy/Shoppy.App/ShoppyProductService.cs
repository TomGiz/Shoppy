namespace Shoppy.App
{
    using Shoppy.App.Os;

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