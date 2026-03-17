using task2.Enum;

namespace task2.Models;

public class User
{
    private int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserType Type { get; set; }

    public int MaxActiveRentals => Type switch
    {
        UserType.Student => 2,
        UserType.Employee => 5,
        _ => 0
    };
}