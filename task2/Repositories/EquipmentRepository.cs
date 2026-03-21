using task2.Database;
using task2.Enum;
using task2.Interfaces;
using task2.Models;

namespace task2.Repositories;

public class EquipmentRepository : IEquipmentRepository {
    private readonly Singleton _database;

    public EquipmentRepository(Singleton database) {
        _database = database;
    }

    public void Add(Equipment equipment) {
        _database.Equipment.Add(equipment);
    }

    public Equipment GetById(int equipmentId) {
        var equipment = _database.Equipment.Find(e => e.Id == equipmentId);
        return equipment ?? throw new Exception("Equipment not found");
    }
    public List<Equipment> GetAll() {
        return _database.Equipment;
    }

    public List<Equipment> GetAvailable() {
        return _database.Equipment.FindAll(e => e.Status == EquipmentStatus.Available);
    }

    public void MarkAsUnavailableById(int equipmentId) {
        GetById(equipmentId).Status = EquipmentStatus.Unavailable;
    }
}