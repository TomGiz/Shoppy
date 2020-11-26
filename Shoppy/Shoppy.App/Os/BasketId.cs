namespace Shoppy.App.Os
{
    using System;

    public readonly struct BasketId
    {
        public BasketId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; }
    }
}
