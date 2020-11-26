namespace Shoppy.App.Os
{
    public readonly struct Money
    {
        public Money(Currency currency, decimal amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public Currency Currency { get; }

        public decimal Amount { get; }
    }
}
