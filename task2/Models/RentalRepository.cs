using task2.Database;
using task2.Interfaces;

namespace task2.Models;

public class RentalRepository : IRentalRepository {
    private readonly Singleton _database = Singleton.Instance;
    public void Add(Rental rental) {
        _database.Rentals.Add(rental);
    }

    public Rental? GetByEquipmentId(int equipmentId) {
        return _database.Rentals.Find(r => r.Equipment.Id == equipmentId);
    }
    public List<Rental> GetAll() {
        return _database.Rentals;
    }
    public List<Rental> GetActiveByUserId(int userId) {
        return _database.Rentals.FindAll(r => r.User.Id == userId && r.ReturnDate == null);
    }
    public List<Rental> GetAllOverdue() {
        return _database.Rentals.FindAll(r => r.DueDate < DateTime.Now);
    }
}