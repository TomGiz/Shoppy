namespace Shoppy.App.Os
{
    /// <summary>
    /// Enumeration class.
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    /// </summary>
    public class Currency : Enumeration<CurrencyCode>
    {
        public static readonly Currency Euro = new Currency(new CurrencyCode{Value = "EUR"}, "Euro");
        public static readonly Currency UsDollar = new Currency(new CurrencyCode{Value = "USD"}, "US Dollar");
        public static readonly Currency GreatBritishPound = new Currency(new CurrencyCode{Value = "GBP"}, "Pound sterling");

        /// <inheritdoc />
        private Currency(CurrencyCode id, string name)
            : base(id, name)
        {
        }
    }
}