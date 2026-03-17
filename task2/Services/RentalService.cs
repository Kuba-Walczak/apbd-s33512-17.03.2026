using System.Runtime.InteropServices.JavaScript;
using task2.Database;
using task2.Enum;
using task2.Interfaces;
using task2.Models;

namespace task2.Services;

public class RentalService : IRentalService
{
    public Singleton Database = Singleton.Instance;

    public void AddUser(User user)
    {
        Database.Users.Add(user);
    }
    public void AddEquipment(Equipment equipment)
    {
        Database.Equipment.Add(equipment);
    }

    public User GetUser(int userId)
    {
        var user = Database.Users.Find(u => u.Id == userId);
        return user ?? throw new Exception("User not found");
    }

    public Equipment GetEquipment(int equipmentId)
    {
        var equipment = Database.Equipment.Find(e => e.Id == equipmentId);
        return equipment ?? throw new Exception("Equipment not found");
    }

    public void MarkUnavailable(int equipmentId)
    {
        GetEquipment(equipmentId).Status = EquipmentStatus.Unavailable;
    }

    public List<Equipment> GetAllEquipment()
    {
        return Database.Equipment;
    }
    
    public List<Equipment> GetAvailableEquipment()
    {
        return Database.Equipment.FindAll(e => e.Status == EquipmentStatus.Available);
    }

    public Rental RentEquipment(int userId, int equipmentId, int days)
    {
        var user = GetUser(userId);
        var equipment = GetEquipment(equipmentId);
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new Exception("Equipment not available");
        }
        var dueDate = DateTime.Today.AddDays(days);
        var rental = new Rental(user, equipment, dueDate);
        Database.Rentals.Add(rental);
        return rental;
    }

    public Rental ReturnEquipment(int equipmentId)
    {
        var equipment = GetEquipment(equipmentId);
        var rental = Database.Rentals.Find(r => r.Equipment.Equals(equipment));
        if (rental == null)
        {
            throw new Exception("Equipment is not being rented");
        }
        var daysLate = (rental.DueDate - DateTime.Now).Days;
        rental.Fee = Math.Max(0, daysLate * 100);
        return rental;
    }

    public List<Rental> GetActiveRentals(int userId)
    {
        var user = GetUser(userId);
        return Database.Rentals.FindAll(r => r.User.Equals(user) && r.ReturnDate == null);
    }

    public List<Rental> GetOverdueRentals()
    {
        return Database.Rentals.FindAll(r => r.DueDate < DateTime.Now);
    }

    public List<Rental> GetAllRentals()
    {
        return Database.Rentals;
    }
}