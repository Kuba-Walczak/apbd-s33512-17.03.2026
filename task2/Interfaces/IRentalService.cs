using task2.Models;

namespace task2.Interfaces;

public interface IRentalService
{
    void addUser(User user);
    void addEquipment(Equipment equipment);
    List<Equipment> getAllEquipment();
    List<Equipment> getAvailableEquipment();
    //Rental RentEquipment(int userId, int equipmentId, int days);
}