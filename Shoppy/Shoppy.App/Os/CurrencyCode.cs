namespace Shoppy.App.Os
{
    using System;

    public struct CurrencyCode : IComparable
    {
        public string Value { get; set; }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            return this.Value?.CompareTo(obj) ?? 1;
        }
    }
}
