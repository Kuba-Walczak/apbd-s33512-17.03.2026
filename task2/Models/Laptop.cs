namespace task2.Models;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public int Storage { get; set; }

    public Laptop(string name, int ram, int storage)
        : base(name)
    {
        Name = name;
        Ram = ram;
        storage = storage;
    }
}