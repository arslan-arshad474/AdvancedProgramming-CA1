using System;
using System.Collections.Generic;

namespace ChurrosShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Order> orderQueue = new Queue<Order>();

            Dictionary<string, Churros> menu = new Dictionary<string, Churros>();
            menu.Add("1", new Churros("Plain sugar", 6.00m));
            menu.Add("2", new Churros("Cinnamon sugar", 6.00m));
            menu.Add("3", new Churros("Chocolate sauce", 8.00m));
            menu.Add("4", new Churros("Nutella", 8.00m));

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("----- Delicious Churros Shop -----");
                Console.WriteLine("1. Place order");
                Console.WriteLine("2. Deliver order");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    PlaceOrder(orderQueue, menu);
                }
                else if (option == "2")
                {
                    DeliverOrder(orderQueue);
                }
                else if (option == "0")
                {
                    exit = true;
                    Console.WriteLine("Program closed. Thank you for visiting!");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        static void PlaceOrder(Queue<Order> orderQueue, Dictionary<string, Churros> menu)
        {
            Console.WriteLine();
            Console.WriteLine("----- Churros Menu -----");
            Console.WriteLine("1. Churros with plain sugar: €6.00");
            Console.WriteLine("2. Churros with cinnamon sugar: €6.00");
            Console.WriteLine("3. Churros with chocolate sauce: €8.00");
            Console.WriteLine("4. Churros with Nutella: €8.00");

            Console.Write("Select churro type: ");
            string choice = Console.ReadLine();

            if (!menu.ContainsKey(choice))
            {
                Console.WriteLine("Invalid churro choice.");
                return;
            }

            Console.Write("Enter quantity: ");
            bool validQuantity = int.TryParse(Console.ReadLine(), out int quantity);

            if (!validQuantity || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            Churros selectedChurros = menu[choice];
            decimal totalBill = selectedChurros.Price * quantity;

            Order order = new Order(selectedChurros.Type, quantity, totalBill);

            Console.WriteLine();
            Console.WriteLine("----- Order Summary -----");
            Console.WriteLine("Order Number: " + order.OrderNo);
            Console.WriteLine("Order Details: " + order.OrderDetails);
            Console.WriteLine("Quantity: " + order.Quantity);
            Console.WriteLine("Total Bill: €" + order.PayBill().ToString("0.00"));

            decimal paidAmount = 0;

            while (paidAmount < totalBill)
            {
                Console.Write("Enter payment amount: €");
                bool validPayment = decimal.TryParse(Console.ReadLine(), out decimal payment);

                if (validPayment && payment > 0)
                {
                    paidAmount = paidAmount + payment;
                }
                else
                {
                    Console.WriteLine("Invalid payment.");
                }
            }

            order.IsPaid = true;
            orderQueue.Enqueue(order);

            Console.WriteLine("Payment received successfully.");

            if (paidAmount > totalBill)
            {
                Console.WriteLine("Change returned: €" + (paidAmount - totalBill).ToString("0.00"));
            }

            Console.WriteLine("Order added to queue successfully.");
            Console.WriteLine("Pending orders in queue: " + orderQueue.Count);
        }

        static void DeliverOrder(Queue<Order> orderQueue)
        {
            if (orderQueue.Count == 0)
            {
                Console.WriteLine("No orders to deliver.");
                return;
            }

            Order nextOrder = orderQueue.Peek();

            Console.WriteLine();
            Console.WriteLine("----- Next Order -----");
            Console.WriteLine("Order Number: " + nextOrder.OrderNo);
            Console.WriteLine("Order Details: " + nextOrder.OrderDetails);
            Console.WriteLine("Quantity: " + nextOrder.Quantity);
            Console.WriteLine("Bill: €" + nextOrder.Bill.ToString("0.00"));

            Console.Write("Deliver this order? (y/n): ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                Order deliveredOrder = orderQueue.Dequeue();
                Console.WriteLine("Order " + deliveredOrder.OrderNo + " delivered successfully.");
                Console.WriteLine("Remaining orders in queue: " + orderQueue.Count);
            }
            else
            {
                Console.WriteLine("Delivery cancelled.");
            }
        }
    }
}