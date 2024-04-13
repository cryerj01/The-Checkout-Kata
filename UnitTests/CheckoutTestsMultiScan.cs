using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Checkout_Kata;

namespace CheckoutTestsMultiScan
{

    [TestClass]
    public class CheckoutTestsMultiScan
    {
        Checkout checkout = new Checkout();
        [TestMethod]
        [DataRow(50, "A")]
        [DataRow(80, "AB")]
        [DataRow(100, "ABC")]
        [DataRow(115, "ABCD")]
        [DataRow(80, "BA")]
        [DataRow(100, "BAC")]
        [DataRow(115, "ADCB")]

        public void AllNumberAddUpWithNoSpecialPrice(int total, string products)
        {
            foreach (char p in products.ToCharArray())
            {
                checkout.Scan(p.ToString());
            }
            Assert.AreEqual(total, checkout.total);
        }

    }
}
