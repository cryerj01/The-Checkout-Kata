using System.ComponentModel.Design;
using The_Checkout_kata;
using The_Checkout_Kata;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        [DataRow(50, "A")]
        [DataRow(80, "AB")]
        [DataRow(100, "ABC")]
        [DataRow(115,"ABCD")]
        //random order
        [DataRow(80, "BA")]
        [DataRow(100, "BAC")]
        [DataRow(115, "ADCB")]

        public void AllNumberAddUpWithNoSpecialPrice(int total,string products)
        {
     
            var checkout = new Checkout();
            checkout.Scan(products);
                      
          Assert.AreEqual(total,checkout.total);


        }

        [TestMethod]
        [DataRow(130, "AAA")]
        [DataRow(260, "AAAAAA")]
        [DataRow(160,"AAAB")]
        public void PricesWithSpecials(int total, string products) {
            var checkout = new Checkout();
            checkout.Scan(products);

            Assert.AreEqual(total, checkout.total);


        }

        [TestMethod]
        [DataRow(20, "AAA")]
        [DataRow(15, "BB")]
        [DataRow(35, "AAABB")]
        [DataRow(35, "AAABBCD")]
        [DataRow(20,"AABA")]

        public void checkSavings(int savings, string products) {

            var checkout = new Checkout();
            checkout.Scan(products);

            Assert.AreEqual(savings, checkout.saving);

        }



    }
}