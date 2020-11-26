namespace Shoppy.App
{
    using Shoppy.App.Os;

    public class ShoppyProductService : IShoppyProductService
    {
        private readonly IProductService<ShoppyProduct> productService;

        private readonly IReviewService reviewService;

        public ShoppyProductService(IProductService<ShoppyProduct> productService, IReviewService reviewService)
        {
            this.productService = productService;
            this.reviewService = reviewService;
        }

        /// <inheritdoc />
        public ShoppyProduct GetProduct(int id)
        {
            var productId = new ProductId(id);
            var product = this.productService.GetProduct(productId);
            product.Reviews = this.reviewService.GetProductReview(productId);
            return product;
        }
    }
}
