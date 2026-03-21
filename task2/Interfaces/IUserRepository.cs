using task2.Models;

namespace task2.Interfaces;

public interface IUserRepository {
    public void Add(User user);
    User GetById(int userId);
}