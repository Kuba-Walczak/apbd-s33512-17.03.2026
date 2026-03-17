using task2.Services;

namespace task2.Models;

public class Printer
{
    public RentalService RentalService;

    public Printer(RentalService rentalService)
    {
        RentalService = rentalService;
    }
    
    public void PrintAllEquipmentWithStatus()
    {
        foreach (var rental in RentalService.GetAllEquipment()) {
            Console.WriteLine(rental.Name + " - " + rental.Status);
        }
    }

    public void PrintAvailableEquipment()
    {
        foreach (var equipment in RentalService.GetAvailableEquipment())
        {
            Console.WriteLine(equipment);
        }
    }

    public void PrintActiveRentals(int userId)
    {
        var user = RentalService.GetUser(userId);
        foreach (var rental in RentalService.GetActiveRentals(userId))
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals()
    {
        foreach (var rental in RentalService.GetOverdueRentals())
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintReport()
    {
        Console.WriteLine("Total rentals: " + RentalService.GetAllRentals().Count + "\n" +
        "Overdue rentals: " + RentalService.GetOverdueRentals().Count);
    }
}