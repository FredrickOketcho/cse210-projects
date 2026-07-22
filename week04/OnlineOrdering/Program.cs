class Program
{
    static void Main(string[] args)
    {
        // --- Order 1 (USA Customer) ---
        Address address1 = new Address("123 Elm St", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "P101", 25.00, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P102", 75.50, 1));

        // --- Order 2 (International Customer) ---
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("HD Monitor", "P201", 150.00, 1));
        order2.AddProduct(new Product("HDMI Cable", "P202", 12.99, 3));
        order2.AddProduct(new Product("Desk Pad", "P203", 20.00, 1));

        // --- Display Results ---
        DisplayOrderDetails(order1, 1);
        Console.WriteLine(new string('-', 40));
        DisplayOrderDetails(order2, 2);
    }

    static void DisplayOrderDetails(Order order, int orderNum)
    {
        Console.WriteLine($"=== ORDER #{orderNum} ===");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order.CalculateTotalCost():F2}\n");
    }
}