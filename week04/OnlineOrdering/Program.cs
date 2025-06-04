using System;

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("203 Criollos de America St", "Luque", "Central", "Paraguay");
        var customer1 = new Customer("Natalio Maciel", address1);

        var address2 = new Address("330 King St", "Springfield", "IL", "USA");
        var customer2 = new Customer("Jose Caceres", address2);

        var address3 = new Address("111 Saint Lius St", "Sacramento", "California", "USA");
        var customer3 = new Customer("Jose Caceres", address3);

        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Iphone15", "AP380", 900.90, 1));
        order1.AddProduct(new Product("USB", "UST30", 15.50, 1));

        var order2 = new Order(customer2);
        order2.AddProduct(new Product("HP Notebook", "NB290", 500.99, 1));
        order2.AddProduct(new Product("Speaker", "SP9393", 30, 2));

        var order3 = new Order(customer3);
        order3.AddProduct(new Product("Sticky notes", "SN382", 1, 4));
        order3.AddProduct(new Product("Pen", "P221", 5, 2));

        static void DisplayOrder(Order order)
        {
            Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
            Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
        }

        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order3);
    }
}