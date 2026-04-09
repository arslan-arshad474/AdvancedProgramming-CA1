using System;

namespace ChurrosShop
{
    public class Churros
    {
        public string Type { get; set; }
        public decimal Price { get; set; }

        public Churros(string type, decimal price)
        {
            Type = type;
            Price = price;
        }
    }
}