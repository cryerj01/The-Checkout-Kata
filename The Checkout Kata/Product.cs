using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Checkout_kata
{
    public class Product : IProduct
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
        public int SpecialPrice { get; set; }
        public int SpecialPriceNoUnits { get; set; }


        public Product(string sku, int unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;

        }

        public Product(string sKU, int unitPrice, int specialPrice, int specialPriceNoUnits) : this(sKU, unitPrice)
        {
            SpecialPrice = specialPrice;
            SpecialPriceNoUnits = specialPriceNoUnits;
        }

    }
}
