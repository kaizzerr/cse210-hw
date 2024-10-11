using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("149 Riverbend St", "Edmonton", "Alberta", "Canada");
        Address address2 = new Address("32 Center St", "Los Angeles", "California", "USA");
        Address address3 = new Address("16 Ave", "Vancouver", "British Columbia", "Canada");

        Customer customer1 = new Customer("Han Kim", address3);
        Customer customer2 = new Customer("Nico Don", address1);
        Customer customer3 = new Customer("Zachariah Robin", address2);

        Product product1 = new Product("Phone", "421", 1200.00, 3);
        Product product2 = new Product("Laptop", "396", 2000.00, 2);
        Product product3 = new Product("PlayStation 5", "578", 800.00, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);
        order2.AddProduct(product2);

        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product2);
        order3.AddProduct(product3);

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.TotalCost()}");

        Console.WriteLine();

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.TotalCost()}");

        Console.WriteLine();

        Console.WriteLine(order3.PackingLabel());
        Console.WriteLine(order3.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.TotalCost()}");
    }
}