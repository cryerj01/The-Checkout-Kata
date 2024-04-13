using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using The_Checkout_kata;

namespace The_Checkout_Kata
{
    public class Checkout : ICheckout
    {

        private List<Product> AvalibleProducts = new List<Product>();

        public Checkout(List<Product> avalibleProducts)
        {
            this.products = new List<Product>();
            this.total = 0;
            this.saving = 0;
            this.AvalibleProducts.AddRange(avalibleProducts);

        }

       private  List<Product> products { get; set; }
        private int total { get; set; }
        private int saving { get; set; }

        public List<Product> GetProducts()
        {
            return products;
        }

        public int GetSavings()
        {
          GetTotalPrice();
            return saving;
        }

        public int GetTotalPrice()
        {
            if (products?.Count == 0) return 0;
            total = 0;
            var noneSpecial = products?.Where(x => x.SpecialPrice == 0).ToList();
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
                total += (templist.Count - wholeDeals * product.SpecialPriceNoUnits) * product.UnitPrice;
                if (wholeDeals <= 0) continue;
                total += (wholeDeals * product.SpecialPrice);
                saving += (product.UnitPrice * templist.Count) - (wholeDeals * product.SpecialPrice);
            }

            return total;
        }


        public void Scan(string item)
        {
            foreach (char a in item.ToCharArray())
            {
                Product product = AvalibleProducts?.Where(x => x.SKU.ToLower() == a.ToString().ToLower()).FirstOrDefault();
                products.Add(product);

            }
        }


    }
}
