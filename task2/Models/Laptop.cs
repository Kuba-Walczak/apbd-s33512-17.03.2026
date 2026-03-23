namespace task2.Models;

public class Laptop : Equipment {
    public int Ram { get; set; }
    public int Storage { get; set; }

    public Laptop(string name, int ram, int storage) : base(name) {
        Ram = ram;
        Storage = storage;
    }
}