using task2.Enum;
using task2.Interfaces;
using task2.Models;

namespace task2.Services;

public class RentalService : IRentalService {
    private readonly IUserRepository _userRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IRentalRepository _rentalRepository;

    public RentalService(IUserRepository userRepository, IEquipmentRepository equipmentRepository, IRentalRepository rentalRepository) {
        _userRepository = userRepository;
        _equipmentRepository = equipmentRepository;
        _rentalRepository = rentalRepository;
    }
    public int PenaltyPerDayLate { get; set; } = 100;
    
    public Rental RentEquipment(int userId, int equipmentId, int days) {
        var user = _userRepository.GetById(userId);
        var userRentals = _rentalRepository.GetActiveByUserId(userId);
        if (userRentals.Count >= user.MaxActiveRentals) {
            throw new Exception("User cannot have more active rentals");
        }
        var equipment = _equipmentRepository.GetById(equipmentId);
        if (equipment.Status != EquipmentStatus.Available) {
            throw new Exception("Equipment not available");
        }
        var dueDate = DateTime.Today.AddDays(days);
        var rental = new Rental(user, equipment, dueDate);
        equipment.Status = EquipmentStatus.Rented;
        _rentalRepository.Add(rental);
        return rental;
    }
    
    public Rental RentEquipment(int userId, int equipmentId, DateTime rentDate, DateTime dueDate) {
        var user = _userRepository.GetById(userId);
        var userRentals = _rentalRepository.GetActiveByUserId(userId);
        if (userRentals.Count >= user.MaxActiveRentals) {
            throw new Exception("User cannot have more active rentals");
        }
        var equipment = _equipmentRepository.GetById(equipmentId);
        if (equipment.Status != EquipmentStatus.Available) {
            throw new Exception("Equipment not available");
        }
        var rental = new Rental(user, equipment, rentDate, dueDate);
        equipment.Status = EquipmentStatus.Rented;
        _rentalRepository.Add(rental);
        return rental;
    }

    public Rental ReturnEquipment(int equipmentId) {
        var rental = _rentalRepository.GetByEquipmentId(equipmentId);
        if (rental == null) {
            throw new Exception("Equipment is not currently being rented");
        }
        rental.ReturnDate = DateTime.Now;
        rental.Equipment.Status = EquipmentStatus.Available;
        var daysLate = (DateTime.Now - rental.DueDate).Days;
        rental.Fee = Math.Max(0, daysLate * PenaltyPerDayLate);
        return rental;
    }
}