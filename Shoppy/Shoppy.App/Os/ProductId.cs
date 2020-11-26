namespace Shoppy.App.Os
{
    public readonly struct ProductId
    {
        public ProductId(int value)
        {
            this.Value = value;
        }

        public int Value { get; }
    }
}
