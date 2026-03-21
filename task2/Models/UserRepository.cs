using task2.Database;
using task2.Interfaces;

namespace task2.Models;

public class UserRepository : IUserRepository {
    private readonly Singleton _database = Singleton.Instance;
    
    public void Add(User user) {
        _database.Users.Add(user);
    }

    public User GetById(int userId) {
        var user = _database.Users.Find(u => u.Id == userId);
        return user ?? throw new Exception("User not found");
    }
}