using task2.Models;

namespace task2.Database;

public class Singleton
{
    private static Singleton? _instance;
    public List<User> Users { get; } = new();
    public List<Equipment> Equipment { get; } = new();
    public List<Rental> Rentals { get; } = new();

    public static Singleton Instance
    {
        get
        {
            _instance ??= new Singleton();
            return _instance;
        }
    }

    private Singleton() { }
}