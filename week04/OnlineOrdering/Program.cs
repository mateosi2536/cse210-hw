using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new("John Smith", address1);

        Order order1 = new(customer1);
        order1.AddProduct(new("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new("Mouse", "P002", 25.50, 2));
        order1.AddProduct(new("Keyboard", "P003", 75.00, 1));

        Address address2 = new("456 Oak Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new("Maria Garcia", address2);

        Order order2 = new(customer2);
        order2.AddProduct(new("Monitor", "P004", 299.99, 2));
        order2.AddProduct(new("Webcam", "P005", 89.99, 1));

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine("\n========== ORDER 2 ==========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.GetTotalCost():F2}");
    }
}