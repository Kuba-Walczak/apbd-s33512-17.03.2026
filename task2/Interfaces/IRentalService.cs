using task2.Models;

namespace task2.Interfaces;

public interface IRentalService {
    public Rental RentEquipment(int userId, int equipmentId, int days);
    public Rental RentEquipment(int userId, int equipmentId, DateTime rentDate, DateTime dueDate);
    public Rental ReturnEquipment(int equipmentId);
}