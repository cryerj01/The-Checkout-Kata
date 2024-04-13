using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Checkout_kata;

namespace The_Checkout_Kata
{
    public interface ICheckout
    {
        public List<Product> products { get; set; }
        public int total { get; set; }
        public int saving { get; set; }

        public void Scan(string item);
        public int GetTotalPrice();
        public List<Product> GetProducts();
    }
}
