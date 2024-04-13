using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Checkout_kata;
using The_Checkout_Kata;

namespace CheckoutTestsMultiScan
{

    [TestClass]
    public class CheckoutTestsTotalMultiScan
    {
        public Checkout checkout = new Checkout(new List<Product> {
                new Product("A", 50, 130, 3),
                new Product("B", 30, 45, 2),
                new Product("C", 20),
                new Product("D", 15) });
        
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
            Assert.AreEqual(total, checkout.GetTotalPrice());
        }

        [TestMethod]
        [DataRow(130, "AAA")]
        [DataRow(260, "AAAAAA")]
        [DataRow(175, "ABAAB")]
        [DataRow(175, "ABABA")]

        public void OnlySpecialsnoExtra(int total, string products)
        {
            foreach (char p in products.ToCharArray())
            {
                checkout.Scan(p.ToString());
            }
            Assert.AreEqual(total, checkout.GetTotalPrice());
        }

        [TestMethod]
        [DataRow(160, "ABAA")]
        [DataRow(165, "ABCAB")]
        [DataRow(275,"BCCBDDAABA")]
        [DataRow(640, "ABDCABCBDAABADAABDABAD")]
       


        public void MixOfSpecialAndNoneSpecial(int total, string products)
        {
            foreach (char p in products.ToCharArray())
            {
                checkout.Scan(p.ToString());
            }
            Assert.AreEqual(total, checkout.GetTotalPrice());
        }

    }
    [TestClass]
    public class CheckoutTestsSavingMultiScan
    {
        public Checkout checkout = new Checkout(new List<Product> {
                new Product("A", 50, 130, 3),
                new Product("B", 30, 45, 2),
                new Product("C", 20),
                new Product("D", 15) });


        [TestMethod]
        [DataRow(20, "AAA")]
        [DataRow(15, "BB")]
        [DataRow(35, "AAABB")]
        [DataRow(35, "AAABBCD")]
        [DataRow(20, "AABA")]
        [DataRow(0, "ABA")]

        public void checkSavings(int savings, string products)
        {
            foreach (char p in products.ToCharArray())
            {
                checkout.Scan(p.ToString());
            }
            Assert.AreEqual(savings, checkout.GetSavings());
        }
        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow("ABC")]
        [DataRow("ABCD")]
        [DataRow("BA")]
        [DataRow("BAC")]
        [DataRow("ADCB")]
        public void checkNoSpecialsSaving(string products)
        {
            foreach (char p in products.ToCharArray())
            {
                checkout.Scan(p.ToString());
            }
            Assert.AreEqual(0, checkout.GetSavings());
        }
    }
}
