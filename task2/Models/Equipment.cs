using task2.Enum;

namespace task2.Models;

public abstract class Equipment
{
    private static int _nextId = 1;
    public int Id { get; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public EquipmentStatus Status { get; set; }
    public DateTime AddedDate { get; set; }

    public Equipment(string name, string description = "", EquipmentStatus status = EquipmentStatus.Available)
    {
        Id = _nextId++;
        Name = name;
        Description = description;
        Status = status;
        AddedDate = DateTime.Now;
    }

    public override string ToString()
    {
        return Id + " " + Name + " " + Description + " " + Status +  " " + AddedDate;
    }
}