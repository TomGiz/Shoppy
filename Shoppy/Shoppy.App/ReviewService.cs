namespace Shoppy.App
{
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Shoppy.App.Os;

    public class ReviewService : IReviewService
    {
        /// <inheritdoc />
        public IEnumerable<ProductReview> GetProductReview(ProductId productId)
        {
            var faker = new Faker();
            return faker.Rant.Reviews()
                .Select(r => new ProductReview { Comments = r, Reviewer = new PersonId { Value = faker.Random.Int() } });
        }
    }
}
