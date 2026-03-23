Equipment Rental System

This console application simulates an equipment rental management system where users can rent and return equipment items (laptops, projectors, cameras). The data is stored in a database implemented as a singleton class that stores users, equipment and rental information. The app also includes features such as: per-user rental limits, overdue detection, and late return fee calculation.

Cohesion

Each class has a single, well-defined reason to exist.
RentalService coordinates only rental and return operations and does not print or manage raw data.
RentalRepository, UserRepository, and EquipmentRepository each manage one entity type. Keeping access methods for all types of data in one class would lead to a bloated file with unrelated methods, decreasing cohesion.
Printer is responsible solely for formatting and writing output to the console and accesses repositories directly since it only needs to read data, not invoke business operations.

Coupling

To keep the coupling loose, I introduced dependency injection wherever I could. Thanks to this, the repository, service and presentation layers can be swapped out without the need to modify code. Also, each layer depends only on abstractions defined in Interfaces/, never on concrete implementations in other layers.

Class Responsibilities

The project is divided into distinct layers, each with a clear responsibility.
* [Model] Models hold only data with no business rules or data access.
* [Repository] Repositories encapsulate all data access logic for the database, meaning the storage mechanism can be swapped without touching any business logic.
* [Service] The rental service contains business rules: rental limit enforcement, equipment availability checks and fee calculation.
* [Presentation] Presentation handles all console output and depends only on repository interfaces, not on the service.