using task2.Enum;

namespace task2.Models;

public class User {
    private static int _nextId = 1;
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserType Type { get; set; }

    public User(string name, string surname, UserType type) {
        Id = _nextId++;
        Name = name;
        Surname = surname;
        Type = type;
    }

    public int MaxActiveRentals => Type switch {
        UserType.Student => 2,
        UserType.Employee => 5,
        _ => 0
    };

    public override string ToString() {
        return Id + " " + Name + " " + Surname + " " + Type;
    }
}