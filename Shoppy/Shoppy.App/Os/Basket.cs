namespace Shoppy.App.Os
{
    using System.Collections.Generic;
    using System.Linq;

    public class Basket<TBasketLine>
        where TBasketLine: BasketLine
    {
        public BasketId Id { get; set; }


        public CustomerId CustomerId { get; set; }

        public IEnumerable<TBasketLine> BasketLines { get; set; }

        /// <summary>
        /// Ooh for simplicity's sake
        /// </summary>
        public Money TotalAmount => new Money(Currency.Euro, this.BasketLines.Sum(x => x.LineAmount.Amount));
    }
}