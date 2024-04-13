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
      

        public void Scan(string item);
        public int GetTotalPrice();
        public int GetSavings();
        public List<Product> GetProducts();
    }
}
