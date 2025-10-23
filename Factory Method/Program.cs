using System;

internal interface IProduct
{
    void Operation();
}

internal sealed class ConcreteProductA : IProduct
{
    public void Operation() => Console.WriteLine("ConcreteProductA operation");
}

internal sealed class ConcreteProductB : IProduct
{
    public void Operation() => Console.WriteLine("ConcreteProductB operation");
}

// Creator declares the factory method that returns IProduct.
internal abstract class Creator
{
    // Factory Method
    public abstract IProduct FactoryMethod();

    // Optional: a method that uses the product returned by the factory method.
    public void SomeOperation()
    {
        var product = FactoryMethod();
        Console.Write("Creator uses product: ");
        product.Operation();
    }
}

// Concrete creators implement the factory method.
// Each concrete creator is a singleton.
internal sealed class ConcreteCreatorA : Creator
{
    private static readonly Lazy<ConcreteCreatorA> _instance = new(() => new ConcreteCreatorA());
    public static ConcreteCreatorA Instance => _instance.Value;

    // Prevent external instantiation
    private ConcreteCreatorA() { }

    public override IProduct FactoryMethod() => new ConcreteProductA();
}

internal sealed class ConcreteCreatorB : Creator
{
    private static readonly Lazy<ConcreteCreatorB> _instance = new(() => new ConcreteCreatorB());
    public static ConcreteCreatorB Instance => _instance.Value;

    private ConcreteCreatorB() { }

    public override IProduct FactoryMethod() => new ConcreteProductB();
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Singleton Factory Method demo:");

        var creatorA1 = ConcreteCreatorA.Instance;
        var creatorA2 = ConcreteCreatorA.Instance;
        Console.WriteLine($"creatorA1 and creatorA2 are same: {ReferenceEquals(creatorA1, creatorA2)}");

        creatorA1.SomeOperation();

        var creatorB = ConcreteCreatorB.Instance;
        Console.WriteLine($"creatorA1 and creatorB are same: {ReferenceEquals(creatorA1, creatorB)}");

        creatorB.SomeOperation();
    }
}