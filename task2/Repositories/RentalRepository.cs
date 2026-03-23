using task2.Database;
using task2.Interfaces;
using task2.Models;

namespace task2.Repositories;

public class RentalRepository : IRentalRepository {
    private readonly Singleton _database;

    public RentalRepository(Singleton database) {
        _database = database;
    }

    public void Add(Rental rental) {
        _database.Rentals.Add(rental);
    }

    public Rental? GetByEquipmentId(int equipmentId) {
        return _database.Rentals.Find(r => r.Equipment.Id == equipmentId && r.ReturnDate == null);
    }
    public List<Rental> GetActiveByUserId(int userId) {
        return _database.Rentals.FindAll(r => r.User.Id == userId && r.ReturnDate == null);
    }
    public List<Rental> GetAll() {
        return _database.Rentals;
    }
    public List<Rental> GetOverdue() {
        return _database.Rentals.FindAll(r => r.DueDate < DateTime.Now && r.ReturnDate == null);
    }
    public List<Rental> GetActive() {
        return _database.Rentals.FindAll(r => r.ReturnDate == null);
    }
}