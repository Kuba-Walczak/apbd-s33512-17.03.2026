using task2.Enum;
using task2.Models;
using task2.Services;

var userRepository = new UserRepository();
var equipmentRepository = new EquipmentRepository();
var rentalRepository = new RentalRepository();
var rentalService = new RentalService(userRepository, equipmentRepository, rentalRepository);
var printer = new Printer(userRepository, equipmentRepository, rentalRepository);

userRepository.Add(new User("Jan", "Kowalski", UserType.Employee));
userRepository.Add(new User("Anna", "Nowak", UserType.Employee));
userRepository.Add(new User("Beata", "Zielińska", UserType.Employee));
userRepository.Add(new User("Piotr", "Szymański", UserType.Employee));

equipmentRepository.Add(new Laptop("Dell", 4, 256));
equipmentRepository.Add(new Laptop("Asus", 8, 512));
equipmentRepository.Add(new Projector("HP", 50, 1920));
equipmentRepository.Add(new Projector("Oracle", 100, 2560));
equipmentRepository.Add(new Camera("Nikon", 12, false));
equipmentRepository.Add(new Camera("Sony", 24, true));

printer.PrintAllEquipmentWithStatus();
printer.PrintReport();