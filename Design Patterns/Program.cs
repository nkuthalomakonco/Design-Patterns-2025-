using System;

internal sealed class Singleton
{
    // Lazy<T> provides lazy, thread-safe initialization by default.
    private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

    // Public accessor to the single instance.
    public static Singleton Instance => _instance.Value;

    // Example state
    public string Name { get; } = "AppSingleton";

    // Prevent external instantiation.
    private Singleton()
    {
        // Initialization logic here
    }

    public void DoWork()
    {
        Console.WriteLine($"Singleton '{Name}' is working. Instance hash: {GetHashCode()}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Singleton pattern demo:");

        var s1 = Singleton.Instance;
        s1.DoWork();

        var s2 = Singleton.Instance;
        Console.WriteLine($"Same instance: {ReferenceEquals(s1, s2)}");
        Console.WriteLine($"s1 hash: {s1.GetHashCode()}, s2 hash: {s2.GetHashCode()}");
        Console.ReadKey();
    }
}