using System;

class Program
{
    // ============================
    // PRODUCT
    // ============================
    // This is the complex object that we want to build.
    // It contains multiple properties that can be configured.
    public class House
    {
        public int Rooms { get; set; }                 // Number of rooms in the house
        public bool HasGarage { get; set; }            // Indicates if the house has a garage
        public bool HasSwimmingPool { get; set; }      // Indicates if the house has a swimming pool
        public string RoofType { get; set; }            // Type of roof (e.g., Tile, Concrete)
    }

    // ============================
    // BUILDER INTERFACE
    // ============================
    // Defines the steps required to build a House.
    // Each method returns IHouseBuilder to support fluent chaining.
    public interface IHouseBuilder
    {
        IHouseBuilder SetRooms(int rooms);              // Sets the number of rooms
        IHouseBuilder AddGarage();                      // Adds a garage
        IHouseBuilder AddSwimmingPool();                // Adds a swimming pool
        IHouseBuilder SetRoof(string roofType);         // Sets the roof type
        House Build();                                  // Returns the final House object
    }

    // ============================
    // CONCRETE BUILDER
    // ============================
    // Implements the builder interface and contains
    // the actual construction logic.
    public class HouseBuilder : IHouseBuilder
    {
        // The house object being built step by step
        private readonly House _house = new();

        // Sets the number of rooms
        public IHouseBuilder SetRooms(int rooms)
        {
            _house.Rooms = rooms;
            return this; // Return builder to allow method chaining
        }

        // Adds a garage to the house
        public IHouseBuilder AddGarage()
        {
            _house.HasGarage = true;
            return this;
        }

        // Adds a swimming pool to the house
        public IHouseBuilder AddSwimmingPool()
        {
            _house.HasSwimmingPool = true;
            return this;
        }

        // Sets the roof type
        public IHouseBuilder SetRoof(string roofType)
        {
            _house.RoofType = roofType;
            return this;
        }

        // Final step: returns the fully constructed house
        public House Build()
        {
            return _house;
        }
    }

    // ============================
    // CLIENT CODE
    // ============================
    // The client uses the builder to create a House
    // without knowing the internal construction details.
    static void Main(string[] args)
    {
        var house = new HouseBuilder()
                        .SetRooms(3)           // Step 1: set number of rooms
                        .AddGarage()           // Step 2: add garage
                        .SetRoof("Tile")       // Step 3: set roof type
                        .Build();              // Step 4: get final object

        Console.WriteLine("House created successfully!");
    }
}
