using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using The_Checkout_kata;
using The_Checkout_Kata;

namespace CheckoutTests
{
    [TestClass]
    public class CheckoutTestsPricebulkScan
    {
        public Checkout checkout = new Checkout();

        [TestMethod]

        [DataRow(50, "A")]
        [DataRow(80, "AB")]
        [DataRow(100, "ABC")]
        [DataRow(115,"ABCD")]
        [DataRow(80, "BA")]
        [DataRow(100, "BAC")]
        [DataRow(115, "ADCB")]

        public void AllNumberAddUpWithNoSpecialPrice(int total,string products)
        {
            
            checkout.Scan(products);
            Assert.AreEqual(total,checkout.total);
        }




        [TestMethod]
        [DataRow(130, "AAA")]
        [DataRow(260, "AAAAAA")]
        [DataRow(160,"AAAB")]
        [DataRow(175, "ABAAB")]
        [DataRow(175, "ABABA")]

        public void PricesWithSpecials(int total, string products) {
            checkout.Scan(products);
            Assert.AreEqual(total, checkout.total);
        }

        [TestMethod]
        [DataRow(160, "ABAA")]
        [DataRow(165,"ABCAB")]

        public void MixOfSpecialAndNoneSpecial(int total, string products) {
            checkout.Scan(products);
            Assert.AreEqual(total, checkout.total);
        }



    }

    [TestClass]
    public class CheckoutTestsSavingsbulkscan {
        public Checkout checkout = new Checkout();


        [TestMethod]
        [DataRow(20, "AAA")]
        [DataRow(15, "BB")]
        [DataRow(35, "AAABB")]
        [DataRow(35, "AAABBCD")]
        [DataRow(20, "AABA")]
        [DataRow(0, "ABA")]

        public void checkSavings(int savings, string products)
        { 
            checkout.Scan(products);
            Assert.AreEqual(savings, checkout.saving);
        }
        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow("ABC")]
        [DataRow("ABCD")]
        //random order
        [DataRow( "BA")]
        [DataRow("BAC")]
        [DataRow("ADCB")]
        public void checkNoSpecialsSaving(string products) {
            checkout.Scan(products);
            Assert.AreEqual(0, checkout.saving);
        }
    }

    [TestClass]
    public class CheckoutTestsPriceMultiScan
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

        public void checkPriceMultiScan(int total,string products) {
        foreach (char p in products.ToCharArray()) {
                checkout.Scan(p.ToString());
            }
        Assert.AreEqual(total, checkout.total);
        }


    }
}