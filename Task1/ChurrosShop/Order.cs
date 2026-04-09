using System;
using System.Collections.Generic;

namespace ChurrosShop
{
    public class Order
    {
        private static int counter = 1;

        public int OrderNo { get; private set; }
        public string OrderDetails { get; set; }
        public int Quantity { get; set; }
        public decimal Bill { get; set; }
        public bool IsPaid { get; set; }

        public Order(string orderDetails, int quantity, decimal bill)
        {
            OrderNo = counter;
            counter++;

            OrderDetails = orderDetails;
            Quantity = quantity;
            Bill = bill;
            IsPaid = false;
        }

        public decimal PayBill()
        {
            return Bill;
        }
    }
}