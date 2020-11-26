namespace Shoppy.App.Os
{
    public static class DecimalExtensions
    {
        public static Money Euros(this decimal d)
        {
            return new Money(Currency.Euro, d);
        }

        public static Money UsDollar(this decimal d)
        {
            return new Money(Currency.UsDollar, d);
        }
    }
}
