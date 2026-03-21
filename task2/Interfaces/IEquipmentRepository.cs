using task2.Models;

namespace task2.Interfaces;

public interface IEquipmentRepository {
    public void Add(Equipment equipment);
    public Equipment GetById(int equipmentId);
    public List<Equipment> GetAll();
    public List<Equipment> GetAvailable();
    public void MarkAsUnavailableById(int equipmentId);
}