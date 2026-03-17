using task2.Models;

namespace task2.Interfaces;

public interface IRentalService
{
    void AddUser(User user);
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllEquipment();
    List<Equipment> GetAvailableEquipment();
    Rental RentEquipment(int userId, int equipmentId, int days);
}