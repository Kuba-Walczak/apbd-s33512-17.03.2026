using task2.Database;
using task2.Interfaces;
using task2.Models;

namespace task2.Repositories;

public class UserRepository : IUserRepository {
    private readonly Singleton _database;

    public UserRepository(Singleton database) {
        _database = database;
    }

    public void Add(User user) {
        _database.Users.Add(user);
    }

    public User GetById(int userId) {
        var user = _database.Users.Find(u => u.Id == userId);
        return user ?? throw new Exception("User not found");
    }
}