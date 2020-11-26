namespace Shoppy.App
{
    using System;
    using System.Collections.Generic;
    using Shoppy.App.Os;

    public class DeliverySlot
    {
        public DateTimeOffset Begin { get; set; }
        public DateTimeOffset End { get; set; }
    }

    public class ShoppyBasketLine : BasketLine
    {
        public ShoppyProduct Product { get; set; }
        public string Comment { get; set; }
    }

    public class ShoppyBasket : Basket<ShoppyBasketLine>
    {
        public DeliverySlot ChosenDeliverySlot { get; set; }
    }

    public class ShoppyProduct : Product
    {
        public Uri MainImage { get; set; }
        public string YouTubeMovieId { get; set; }

        public IEnumerable<ProductReview> Reviews { get; set; }

    }

    public class ProductReview
    {
        public PersonId Reviewer { get; set; }

        public string Comments { get; set; }

        public string[] Pros { get; set; }

        public string[] Cons { get; set; }
    }
}
