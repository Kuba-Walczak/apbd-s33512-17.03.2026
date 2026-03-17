using task2.Database;
using task2.Interfaces;
using task2.Models;

namespace task2.Services;

public class RentalService : IRentalService
{
    public Singleton Database = Singleton.Instance;
    public List<User> Users { get; set; } = null!;

    public void addUser(User user)
    {
        Users.Add(user);
    }
}