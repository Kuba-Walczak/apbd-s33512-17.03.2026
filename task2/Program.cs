using task2.Database;
using task2.Enum;
using task2.Models;
using task2.Presentation;
using task2.Repositories;
using task2.Services;

var database = Singleton.Instance;

var userRepository = new UserRepository(database);
var equipmentRepository = new EquipmentRepository(database);
var rentalRepository = new RentalRepository(database);

var rentalService = new RentalService(userRepository, equipmentRepository, rentalRepository);

var printer = new Printer(userRepository, equipmentRepository, rentalRepository);

//adding several equipment items of different types
var equipment1 = new Laptop("Dell", 4, 256);
var equipment2 = new Laptop("Asus", 8, 512);
var equipment3 = new Projector("HP", 50, 1920);
var equipment4 = new Projector("Oracle", 100, 2560);
var equipment5 = new Camera("Nikon", 12, false);
var equipment6 = new Camera("Sony", 24, true);
equipmentRepository.Add(equipment1);
equipmentRepository.Add(equipment2);
equipmentRepository.Add(equipment3);
equipmentRepository.Add(equipment4);
equipmentRepository.Add(equipment5);
equipmentRepository.Add(equipment6);

//adding several users of different types
var user1 = new User("Jan", "Kowalski", UserType.Employee);
var user2 = new User("Anna", "Nowak", UserType.Student);
var user3 = new User("Beata", "Zielińska", UserType.Employee);
var user4 = new User("Piotr", "Szymański", UserType.Student);
userRepository.Add(user1);
userRepository.Add(user2);
userRepository.Add(user3);
userRepository.Add(user4);

//correct rental operation
rentalService.RentEquipment(user1.Id, equipment2.Id, 5);

//an attempted invalid operation: exceeding a user limit (max 2)
rentalService.RentEquipment(user2.Id, equipment3.Id, 5);
rentalService.RentEquipment(user2.Id, equipment4.Id, 7);
rentalService.RentEquipment(user2.Id, equipment5.Id, 2);

//a return completed on time
rentalService.ReturnEquipment(equipment2.Id);

//renting with a past date to showcase a delayed return
rentalService.RentEquipment(user3.Id, equipment2.Id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));

//a delayed return that leads to a penalty
rentalService.ReturnEquipment(equipment2.Id);

//displaying a final report of the system state
printer.PrintReport();