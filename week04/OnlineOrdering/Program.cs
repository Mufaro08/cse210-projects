using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT001", 1200.00, 1));
        order1.AddProduct(new Product("Mouse", "MSE234", 25.00, 2));

        // Order 2 (International)
        Address address2 = new Address("45 Oxford Road", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "SPH789", 800.00, 1));
        order2.AddProduct(new Product("Charger", "CHR123", 30.00, 2));
        order2.AddProduct(new Product("Case", "CSE456", 15.00, 1));

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
    }
}
