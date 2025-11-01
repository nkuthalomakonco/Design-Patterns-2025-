// Facade pattern provides a simplified interface to a complex subsystem.
//The Facade Pattern is a structural design pattern that provides a simplified interface to a complex subsystem of classes, 
//    libraries, or frameworks. It hides the complexity of the system and makes it easier for clients to interact with it.

//Key points:

//Simplifies usage of a complex system.

//Decouples client code from the subsystem.

//Improves readability and maintainability.

#region Client Code
class Program
{
     static void Main(string[] args)
    {
        OrderFacade orderFacade = new OrderFacade();

        orderFacade.PlaceOrder(
            customer: "Alice",
            product: "Laptop",
            quantity: 1,
            amount: 1200.00,
            address: "123 Main Street"
        );
    }
}
#endregion 
#region Subsystem Classes

// Inventory subsystem
public class Inventory
{
    public bool CheckStock(string product, int quantity)
    {
        Console.WriteLine($"Checking stock for {quantity} of {product}...");
        // Assume all products are in stock
        return true;
    }

    public void RemoveFromStock(string product, int quantity)
    {
        Console.WriteLine($"{quantity} of {product} removed from inventory.");
    }
}

// Payment subsystem
public class Payment
{
    public bool ProcessPayment(string customer, double amount)
    {
        Console.WriteLine($"Processing payment of ${amount} for {customer}...");
        // Assume payment always succeeds
        return true;
    }
}

// Shipping subsystem
public class Shipping
{
    public void ShipProduct(string product, string address)
    {
        Console.WriteLine($"Shipping {product} to {address}...");
    }
}

#endregion//
#region Facade Class
public class OrderFacade
{
    private Inventory inventory;
    private Payment payment;
    private Shipping shipping;

    public OrderFacade()
    {
        inventory = new Inventory();
        payment = new Payment();
        shipping = new Shipping();
    }

    public void PlaceOrder(string customer, string product, int quantity, double amount, string address)
    {
        Console.WriteLine("Starting order process...\n");

        if (!inventory.CheckStock(product, quantity))
        {
            Console.WriteLine("Order failed: Product out of stock.");
            return;
        }

        if (!payment.ProcessPayment(customer, amount))
        {
            Console.WriteLine("Order failed: Payment declined.");
            return;
        }

        inventory.RemoveFromStock(product, quantity);
        shipping.ShipProduct(product, address);

        Console.WriteLine("\nOrder completed successfully!");
    }
}
#endregion// 
