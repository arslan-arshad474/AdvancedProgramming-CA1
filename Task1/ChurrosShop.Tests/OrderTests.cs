using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurrosShop;

namespace ChurrosShop.Tests
{
    [TestClass]
    public sealed class PayBillTests
    {
        [TestMethod]
        public void Test_PayBill()
        {
            Order order1 = new Order("Plain sugar", 3, 18.00m);

            decimal result;

            result = order1.PayBill();

            Assert.AreEqual(result, 18.00m);
        }
    }
}