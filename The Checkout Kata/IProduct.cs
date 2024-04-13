namespace The_Checkout_kata
{
    public interface IProduct
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
        public int SpecialPrice { get; set; }
        public int SpecialPriceNoUnits { get; set; }

    }
}
