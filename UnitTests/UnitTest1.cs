using System.ComponentModel.Design;
using The_Checkout_kata;
using The_Checkout_Kata;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AllNumberAddUpWithNoSpecialPrice()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("A", 50, 130, 3));
            products.Add(new Product("B", 30, 45, 2));
            products.Add(new Product("C", 20));
            products.Add(new Product("D", 15));



            var checkout = new Checkout();
            
            products.ForEach(p => { checkout.Scan(p);
                Console.WriteLine(checkout.total);
                checkout.GetTotalPrice();
                Console.WriteLine(checkout.total);
            });


            int value = 50 + 30 + 20 + 15;
          Assert.AreEqual(value,checkout.total, "total is : " + checkout.total + ". value is : " +value );


        }
    }
}