namespace task2.Database;

public class Singleton
{
    private static Singleton? _instance;
    public static Singleton Instance
    {
        get
        {
            _instance ??= new Singleton();
            return _instance;
        }
    }

    private Singleton() { }

    //TODO: add collections for items in the exercise
    //public List<Class> Class { get; } = new();
}