namespace Shoppy.App.Os
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualBasic.CompilerServices;

    public struct CurrencyCode: IComparable
    {
        public string Value { get; set; }

        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return -1;
            }

            return this.Value?.CompareTo(obj) ?? 1;
        }
    }


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

    public readonly struct Money
    {
        public Money(Currency currency, decimal amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public Currency Currency { get;  }

        public decimal Amount { get; }
    }

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

    public class BasketLine
    {
        public BasketLineId Id { get; set; }
        public ProductId ProductId { get; set; }

        public int Quantity { get; set; }

        public Money LineAmount { get; set; }
    }

    public struct BasketLineId
    {
        public int Value { get; set; }
    }


    public struct BasketId
    {
        public Guid Value { get; set; }
    }

    public struct CustomerId
    {
        public int Value { get; set; }
    }

    public struct PersonId
    {
        public int Value { get; set; }
    }

    public struct ProductId
    {
        public int Value { get; set; }
    }

    public class Product
    {
        public ProductId Id { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public Money Price { get; set; }

    }
}
