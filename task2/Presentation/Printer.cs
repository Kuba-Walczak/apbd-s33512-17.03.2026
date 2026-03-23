using task2.Interfaces;

namespace task2.Presentation;

public class Printer {
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IRentalRepository _rentalRepository;

    public Printer(IEquipmentRepository equipmentRepository, IRentalRepository rentalRepository) {
        _equipmentRepository = equipmentRepository;
        _rentalRepository = rentalRepository;
    }

    public void PrintAllEquipmentWithStatus() {
        Console.WriteLine("EQUIPMENT - STATUS");
        foreach (var equipment in _equipmentRepository.GetAll()) {
            Console.WriteLine(equipment.Name + " - " + equipment.Status);
        }
    }

    public void PrintAvailableEquipment() {
        Console.WriteLine("ALL AVAILABLE EQUIPMENT");
        foreach (var equipment in _equipmentRepository.GetAvailable()) {
            Console.WriteLine(equipment);
        }
    }

    public void PrintActiveRentals(int userId) {
        Console.WriteLine("ACTIVE RENTALS");
        foreach (var rental in _rentalRepository.GetActiveByUserId(userId)) {
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals() {
        Console.WriteLine("OVERDUE RENTALS");
        foreach (var rental in _rentalRepository.GetOverdue()) {
            Console.WriteLine(rental);
        }
    }

    public void PrintReport() {
        Console.WriteLine("REPORT");
        Console.WriteLine("Total rentals: " + _rentalRepository.GetAll().Count + "\n" +
        "Active: " + _rentalRepository.GetActive().Count + "\n" + 
        "Overdue: " + _rentalRepository.GetOverdue().Count + "\n" +
        string.Join("\n", _rentalRepository.GetAll()));
    }
}