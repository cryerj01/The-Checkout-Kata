using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using The_Checkout_kata;

namespace The_Checkout_Kata
{
    public class Checkout : ICheckout
    {
        public Checkout(List<Product> products, int total, int saving)
        {
            this.products = products;
            this.total = total;
            this.saving = saving;
        }
        public Checkout()
        {
            this.products = new List<Product>();
            this.total = 0;
            this.saving = 0;
        }

        public List<Product> products { get; set; }
        public int total { get ; set; }
        public int saving { get; set; }

        public List<Product> GetProducts()
        {
            return products;
        }

        public int GetTotalPrice()
        {
            if (products?.Count == 0) return 0;
            total = 0;
            var noneSpecial = products.Where(x => x.SpecialPrice == 0).ToList();
            total = noneSpecial.Sum(x => x.UnitPrice);

            var special = products.Where(x => x.SpecialPrice != 0).ToList();
            if (special == null) return total;

            List<string> checkedType = new List<string>();
            foreach (var product in special)
            {
                if (checkedType.Contains(product.SKU)) continue;
                checkedType.Add(product.SKU);
                var templist = products.Where(x => x.SKU == product.SKU).ToList();
                var wholeDeals = (int)templist.Count() / product.SpecialPriceNoUnits;
                total += (templist.Count - wholeDeals) * product.UnitPrice;
                if (wholeDeals <= 0) continue;
                total += (wholeDeals * product.SpecialPrice);
            }

            return total;
        }


        public void Scan(Product item)
        {
            products.Add(item);
        }


    }
}
