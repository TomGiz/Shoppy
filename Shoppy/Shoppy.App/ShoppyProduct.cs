namespace Shoppy.App
{
    using System;
    using System.Collections.Generic;
    using Shoppy.App.Os;

    public class ShoppyProduct : Product
    {
        public Uri MainImage { get; set; }

        public string YouTubeMovieId { get; set; }

        public IEnumerable<ProductReview> Reviews { get; set; }
    }
}
