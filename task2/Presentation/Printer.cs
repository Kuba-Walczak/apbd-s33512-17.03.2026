using task2.Interfaces;
using task2.Services;

namespace task2.Presentation;

public class Printer {
    private readonly IUserRepository _userRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IRentalRepository _rentalRepository;

    public Printer(IUserRepository userRepository, IEquipmentRepository equipmentRepository, IRentalRepository rentalRepository) {
        _userRepository = userRepository;
        _equipmentRepository = equipmentRepository;
        _rentalRepository = rentalRepository;
    }

    public void PrintAllEquipmentWithStatus() {
        foreach (var equipment in _equipmentRepository.GetAll()) {
            Console.WriteLine("EQUIPMENT - STATUS");
            Console.WriteLine(equipment.Name + " - " + equipment.Status);
        }
    }

    public void PrintAvailableEquipment() {
        foreach (var equipment in _equipmentRepository.GetAvailable()) {
            Console.WriteLine("ALL AVAILABLE EQUIPMENT");
            Console.WriteLine(equipment);
        }
    }

    public void PrintActiveRentals(int userId) {
        foreach (var rental in _rentalRepository.GetActiveByUserId(userId)) {
            Console.WriteLine("ACTIVE RENTALS");
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals() {
        foreach (var rental in _rentalRepository.GetAllOverdue()) {
            Console.WriteLine("OVERDUE RENTALS");
            Console.WriteLine(rental);
        }
    }

    public void PrintReport() {
        Console.WriteLine("Total rentals: " + _rentalRepository.GetAll().Count + "\n" +
                          "Overdue rentals: " + _rentalRepository.GetAllOverdue().Count);
    }
}