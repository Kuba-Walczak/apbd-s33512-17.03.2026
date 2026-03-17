using System.Diagnostics;
using task2.Enum;
using task2.Models;
using task2.Services;

var rentalService = new RentalService();
var printer = new Printer(rentalService);

rentalService.AddUser(new User("Jan", "Kowalski", UserType.Employee));
rentalService.AddUser(new User("Anna", "Nowak", UserType.Employee));
rentalService.AddUser(new User("Beata", "Zielińska", UserType.Employee));
rentalService.AddUser(new User("Piotr", "Szymański", UserType.Employee));

rentalService.AddEquipment(new Laptop("Dell", 4, 256));
rentalService.AddEquipment(new Laptop("Asus", 8, 512));
rentalService.AddEquipment(new Projector("HP", 50, 1920));
rentalService.AddEquipment(new Projector("Oracle", 100, 2560));
rentalService.AddEquipment(new Camera("Nikon", 12, false));
rentalService.AddEquipment(new Camera("Sony", 24, true));

printer.PrintAllEquipmentWithStatus();
printer.PrintReport();