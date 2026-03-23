using task2.Models;

namespace task2.Interfaces;

public interface IRentalRepository {
    public void Add(Rental rental);
    public Rental? GetByEquipmentId(int equipmentId);
    public List<Rental> GetActiveByUserId(int userId);
    public List<Rental> GetAll();
    public List<Rental> GetOverdue();
    public List<Rental> GetActive();
    
}