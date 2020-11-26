namespace Shoppy.App
{
    using Shoppy.App.Os;

    public class ProductReview
    {
        public PersonId Reviewer { get; set; }

        public string Comments { get; set; }

        public string[] Pros { get; set; }

        public string[] Cons { get; set; }
    }
}