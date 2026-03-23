namespace task2.Models;

public class Rental {
    public User User { get; set; } = null!;
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int Fee { get; set; }

    public Rental(User user, Equipment equipment, DateTime dueDate) {
        User = user;
        Equipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = dueDate;
    }
    
    public Rental(User user, Equipment equipment, DateTime rentDate, DateTime dueDate) {
        User = user;
        Equipment = equipment;
        RentalDate = rentDate;
        DueDate = dueDate;
    }

    public override string ToString() {
        return $"User: {User} | Equipment: {Equipment} | Rented: {RentalDate:yyyy-MM-dd} | Due: {DueDate:yyyy-MM-dd} | Returned: {ReturnDate?.ToString("yyyy-MM-dd") ?? "N/A"} | Fee: {(ReturnDate == null ? "N/A" : Fee)}";
    }
}