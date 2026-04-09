using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurrosShop;

namespace ChurrosShop.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void PayBill_ReturnsCorrectBill()
        {
            Order order = new Order("Plain sugar", 3, 18.00m);

            decimal result = order.PayBill();

            Assert.AreEqual(18.00m, result);
        }
    }
}